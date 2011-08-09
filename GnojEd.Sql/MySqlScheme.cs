namespace GnojEd.Sql {
  using System;
  using System.Linq;
  using System.Text;
  using System.Xml.Linq;

  /// <summary>
  /// MySqlScheme class
  /// </summary>
  public class MySqlScheme : IDataScheme {
    /// <summary>
    /// Line feed string
    /// </summary>
    private static string linefeed = "\r\n";

    /// <summary>
    /// StringBuilder object
    /// </summary>
    private StringBuilder builder = new StringBuilder();

    /// <summary>
    /// Gets or sets a value indicating whether to use a DROP statement
    /// </summary>
    public bool CreateDropStatement {
      get;
      set;
    }

    /// <summary>
    /// Gets the Result string
    /// </summary>
    public string Result {
      get {
        return this.builder.ToString();
      }
    }

    /// <summary>
    /// Initialize database scheme from XML
    /// </summary>
    /// <param name="database">Xml rootnode of scheme file</param>
    public void Init(XElement database) {
      this.CreateDropStatement = database.Attribute("drop") != null ? bool.Parse(database.Attribute("drop").Value) : false;

      this.builder.AppendFormat("SET @OLD_UNIQUE_CHECKS = @@UNIQUE_CHECKS, UNIQUE_CHECKS = 0;{0}", linefeed);
      this.builder.AppendFormat("SET @OLD_FOREIGN_KEY_CHECKS = @@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS = 0;{0}", linefeed);
      this.builder.AppendFormat("SET @OLD_SQL_MODE = @@SQL_MODE, SQL_MODE = 'TRADITIONAL';{0}", linefeed);
      this.builder.AppendFormat("-- -----------------------------------------------------{0}", linefeed);
      this.builder.AppendFormat("-- Create scheme{0}", linefeed);
      this.builder.AppendFormat("-- -----------------------------------------------------{0}", linefeed);
      this.builder.AppendFormat(";{0}", linefeed);
      
      string schemeName = database.Attribute("name") != null ? database.Attribute("name").Value : null;

      if (!String.IsNullOrEmpty(schemeName)) {
        if (this.CreateDropStatement) {
          this.builder.AppendFormat("DROP SCHEMA IF EXISTS `{0}`;{1}", schemeName, linefeed);
        }

        this.builder.AppendFormat("CREATE SCHEMA IF NOT EXISTS `{0}` DEFAULT CHARACTER SET utf8 COLLATE default;{1}", schemeName, linefeed);
        this.builder.AppendFormat("USE `{0}`;{1}{1}", schemeName, linefeed);
      }
    }

    /// <summary>
    /// Ready method
    /// </summary>
    public void Ready() {
      this.builder.AppendFormat("SET SQL_MODE = @OLD_SQL_MODE;{0}", linefeed);
      this.builder.AppendFormat("SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS;{0}", linefeed);
      this.builder.AppendFormat("SET UNIQUE_CHECKS = @OLD_UNIQUE_CHECKS;{0}", linefeed);
    }

    /// <summary>
    /// ProcessTable method
    /// </summary>
    /// <param name="table">Xml table element</param>
    public void ProcessTable(XElement table) {
      string tableName = table.Attribute("name").Value;

      this.builder.AppendFormat("-- -----------------------------------------------------{0}", linefeed);
      this.builder.AppendFormat("-- Table `{0}`{1}", tableName, linefeed);
      this.builder.AppendFormat("-- -----------------------------------------------------{0}", linefeed);
      this.builder.AppendFormat(";{0}", linefeed);
      
      if (this.CreateDropStatement) {
        this.builder.AppendFormat("DROP TABLE IF EXISTS `{0}`;{1}", tableName, linefeed);
      }

      this.builder.AppendFormat("CREATE TABLE IF NOT EXISTS `{0}` ({1}", tableName, linefeed);

      table.Descendants("field")
           .ToList()
           .ForEach(field => this.ProcessField(field));
      table.Descendants("primary")
           .ToList()
           .ForEach(primary => this.ProcessPrimary(primary));
      table.Descendants("constraint")
           .ToList()
           .ForEach(constraint => this.ProcessConstraint(constraint));

      this.builder.Replace(String.Format(",{0}", linefeed), linefeed, this.builder.Length - 3, 3);
      this.builder.AppendFormat("){0}", linefeed);
      this.builder.AppendFormat("ENGINE = InnoDB DEFAULT CHARSET=utf8;{0}", linefeed);
      this.builder.AppendFormat("{0}", linefeed);

      table.Descendants("field")
           .Where(field => field.Attribute("index") != null && field.Attribute("index").Value == "true")
           .ToList()
           .ForEach(index => this.ProcessIndex(index));

      this.builder.AppendFormat("{0}{0}", linefeed);

      if (table.Element("data") != null && table.Element("data").Elements("value") != null) {
        //// er zijn waarden om toe te voegen
        this.builder.AppendFormat("-- -----------------------------------------------------{0}", linefeed);
        this.builder.AppendFormat("-- Data for `{0}`{1}", tableName, linefeed);
        this.builder.AppendFormat("-- -----------------------------------------------------{0}", linefeed);
        this.builder.AppendFormat(";{0}", linefeed);

        table.Element("data")
             .Elements("value")
             .ToList()
             .ForEach(value => this.Insert(table, value));
        this.builder.AppendFormat("COMMIT;{0}{0}", linefeed);
      }
    }

    /// <summary>
    /// ProcessField method
    /// </summary>
    /// <param name="field">Xml field element</param>
    private void ProcessField(XElement field) {
      this.builder.AppendFormat("  `{0}`", field.Attribute("name").Value);
      this.builder.AppendFormat(" {0}", field.Attribute("datatype").Value);

      if (field.Attribute("null") != null && field.Attribute("null").Value == "true") {
        this.builder.AppendFormat(" NULL");
      }
      else {
        this.builder.AppendFormat(" NOT NULL", field.Attribute("datatype").Value);
      }

      if (field.Element("constraint") != null && field.Element("constraint").Attribute("type") != null && field.Element("constraint").Attribute("type").Value == "PK") {
        this.builder.AppendFormat(" AUTO_INCREMENT");
      }

      if (field.Element("default") != null && !String.IsNullOrEmpty(field.Element("default").Value)) {
        this.builder.AppendFormat(" DEFAULT {0}", field.Element("default").Value);
      }

      this.builder.AppendFormat(",{0}", linefeed);
    }

    /// <summary>
    /// ProcessPrimary method
    /// </summary>
    /// <param name="primary">Xml primary element</param>
    private void ProcessPrimary(XElement primary) {
      this.builder.AppendFormat("  ");
      this.builder.AppendFormat("PRIMARY KEY (");
      primary.Value
             .Split(',')
             .ToList()
             .ForEach(key => this.builder.AppendFormat("`{0}`,", key.Trim()));
      this.builder.Remove(this.builder.Length - 1, 1);
      this.builder.AppendFormat("),{0}", linefeed);
    }

    /// <summary>
    /// ProcessConstraint method
    /// </summary>
    /// <param name="constraint">Xml constraint element</param>
    private void ProcessConstraint(XElement constraint) {
      Constraint c = (Constraint)Enum.Parse(typeof(Constraint), constraint.Attribute("type").Value);

      this.builder.AppendFormat("  ");
      switch (c) {
        case Constraint.PK:
          this.builder.AppendFormat("PRIMARY KEY (`{0}`)", constraint.Parent.Attribute("name").Value);
          break;
        case Constraint.FK:
        case Constraint.CK:
          this.builder.AppendFormat(
            "CONSTRAINT `fk_{0}_{1}_{2}_{3}`",
            constraint.Ancestors("table").FirstOrDefault().Attribute("name").Value,
            constraint.Parent.Attribute("name").Value,
            constraint.Attribute("table").Value,
            constraint.Attribute("field").Value);
          this.builder.AppendFormat(" FOREIGN KEY (`{0}`)", constraint.Parent.Attribute("name").Value);
          this.builder.AppendFormat(
            " REFERENCES `{0}` (`{1}`)",
            constraint.Attribute("table").Value, 
            constraint.Attribute("field").Value);

          //// RESTRICT | CASCADE | SET NULL | NO ACTION
          if (constraint.Attribute("cascade") != null && constraint.Attribute("cascade").Value == "true") {
            this.builder.AppendFormat(" ON DELETE CASCADE");
            this.builder.AppendFormat(" ON UPDATE NO ACTION");
          }
          else if (constraint.Attribute("setnull") != null && constraint.Attribute("setnull").Value == "true") {
            this.builder.AppendFormat(" ON DELETE SET NULL");
            this.builder.AppendFormat(" ON UPDATE NO ACTION");
          }
          else {
            this.builder.AppendFormat(" ON DELETE RESTRICT");
            this.builder.AppendFormat(" ON UPDATE NO ACTION");
          }

          break;
      }

      this.builder.AppendFormat(",{0}", linefeed);
    }

    /// <summary>
    /// ProcessIndex method
    /// </summary>
    /// <param name="index">Xml index element</param>
    private void ProcessIndex(XElement index) {
      this.builder.AppendFormat("CREATE INDEX `idx_{0}_{1}`", index.Parent.Attribute("name").Value, index.Attribute("name").Value);
      this.builder.AppendFormat(" ON `{0}`", index.Parent.Attribute("name").Value);
      this.builder.AppendFormat(" (`{0}` ASC);{1}", index.Attribute("name").Value, linefeed);
    }

    /// <summary>
    /// Insert method
    /// </summary>
    /// <param name="table">Xml table element</param>
    /// <param name="value">Xml value element</param>
    private void Insert(XElement table, XElement value) {
      this.builder.AppendFormat("INSERT INTO `{0}` (", table.Attribute("name").Value);
      foreach (var field in table.Elements("field")) {
        this.builder.AppendFormat("`{0}`,", field.Attribute("name").Value);
      }

      this.builder.Remove(this.builder.Length - 1, 1);
      this.builder.AppendFormat(") VALUES ({0});{1}", value.Value, linefeed);
    }
  }
}
