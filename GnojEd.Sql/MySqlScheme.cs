namespace GnojEd.Sql {
  using System;
  using System.Linq;
  using System.Text;
  using System.Xml.Linq;

  /// <summary>
  /// 
  /// </summary>
  public class MySqlScheme : IDataScheme {
    /// <summary>
    /// 
    /// </summary>
    private static string CrLf = "\r\n";

    /// <summary>
    /// 
    /// </summary>
    private StringBuilder builder = new StringBuilder();

    /// <summary>
    /// 
    /// </summary>
    public bool CreateDropStatement {
      get;
      set;
    }

    /// <summary>
    /// 
    /// </summary>
    public string Result {
      get {
        return builder.ToString();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="database"></param>
    public void Init(XElement database) {
      this.CreateDropStatement = database.Attribute("drop") != null ? bool.Parse(database.Attribute("drop").Value) : false;

      builder.AppendFormat("SET @OLD_UNIQUE_CHECKS = @@UNIQUE_CHECKS, UNIQUE_CHECKS = 0;{0}", CrLf);
      builder.AppendFormat("SET @OLD_FOREIGN_KEY_CHECKS = @@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS = 0;{0}", CrLf);
      builder.AppendFormat("SET @OLD_SQL_MODE = @@SQL_MODE, SQL_MODE = 'TRADITIONAL';{0}", CrLf);

      builder.AppendFormat("-- -----------------------------------------------------{0}", CrLf);
      builder.AppendFormat("-- Create scheme{0}", CrLf);
      builder.AppendFormat("-- -----------------------------------------------------{0}", CrLf);
      builder.AppendFormat(";{0}", CrLf);
      string schemeName = database.Attribute("name") != null ? database.Attribute("name").Value : null;

      if (!String.IsNullOrEmpty(schemeName)) {
        if (this.CreateDropStatement) {
          builder.AppendFormat("DROP SCHEMA IF EXISTS `{0}`;{1}", schemeName, CrLf);
        }

        builder.AppendFormat("CREATE SCHEMA IF NOT EXISTS `{0}` DEFAULT CHARACTER SET utf8 COLLATE default;{1}", schemeName, CrLf);
        builder.AppendFormat("USE `{0}`;{1}{1}", schemeName, CrLf);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Ready() {
      builder.AppendFormat("SET SQL_MODE = @OLD_SQL_MODE;{0}", CrLf);
      builder.AppendFormat("SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS;{0}", CrLf);
      builder.AppendFormat("SET UNIQUE_CHECKS = @OLD_UNIQUE_CHECKS;{0}", CrLf);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="table"></param>
    public void ProcessTable(XElement table) {
      string tableName = table.Attribute("name").Value;

      builder.AppendFormat("-- -----------------------------------------------------{0}", CrLf);
      builder.AppendFormat("-- Table `{0}`{1}", tableName, CrLf);
      builder.AppendFormat("-- -----------------------------------------------------{0}", CrLf);
      builder.AppendFormat(";{0}", CrLf);
      if (this.CreateDropStatement) {
        builder.AppendFormat("DROP TABLE IF EXISTS `{0}`;{1}", tableName, CrLf);
      }

      builder.AppendFormat("CREATE TABLE IF NOT EXISTS `{0}` ({1}", tableName, CrLf);

      table.Descendants("field")
           .ToList()
           .ForEach(field => this.ProcessField(field));
      table.Descendants("primary")
           .ToList()
           .ForEach(primary => this.ProcessPrimary(primary));
      table.Descendants("constraint")
           .ToList()
           .ForEach(constraint => this.ProcessConstraint(constraint));

      builder.Replace(String.Format(",{0}", CrLf), CrLf, builder.Length - 3, 3);
      builder.AppendFormat("){0}", CrLf);
      builder.AppendFormat("ENGINE = InnoDB DEFAULT CHARSET=utf8;{0}", CrLf);
      builder.AppendFormat("{0}", CrLf);

      table.Descendants("field")
           .Where(field => field.Attribute("index") != null && field.Attribute("index").Value == "true")
           .ToList()
           .ForEach(index => this.ProcessIndex(index));

      builder.AppendFormat("{0}{0}", CrLf);

      if (table.Element("data") != null && table.Element("data").Elements("value") != null) {
        // er zijn waarden om toe te voegen
        builder.AppendFormat("-- -----------------------------------------------------{0}", CrLf);
        builder.AppendFormat("-- Data for `{0}`{1}", tableName, CrLf);
        builder.AppendFormat("-- -----------------------------------------------------{0}", CrLf);
        builder.AppendFormat(";{0}", CrLf);
        //builder.AppendFormat("SET @OLD_AUTOCOMMIT = @@AUTOCOMMIT;{0}", CrLf);
        //builder.AppendFormat("SET AUTOCOMMIT = 0;{0}", CrLf);
        table.Element("data")
             .Elements("value")
             .ToList()
             .ForEach(value => this.Insert(table, value));
        builder.AppendFormat("COMMIT;{0}{0}", CrLf);
        //builder.AppendFormat("SET AUTOCOMMIT = @@OLD_AUTOCOMMIT;{0}{0}", CrLf);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="field"></param>
    private void ProcessField(XElement field) {
      builder.AppendFormat("  `{0}`", field.Attribute("name").Value);
      builder.AppendFormat(" {0}", field.Attribute("datatype").Value);
      if (field.Attribute("null") != null && field.Attribute("null").Value == "true") {
        builder.AppendFormat(" NULL");
      }
      else {
        builder.AppendFormat(" NOT NULL", field.Attribute("datatype").Value);
      }
      if (field.Element("constraint") != null && field.Element("constraint").Attribute("type") != null && field.Element("constraint").Attribute("type").Value == "PK") {
        builder.AppendFormat(" AUTO_INCREMENT");
      }
      if (field.Element("default") != null && !String.IsNullOrEmpty(field.Element("default").Value)) {
        builder.AppendFormat(" DEFAULT {0}", field.Element("default").Value);
      }
      builder.AppendFormat(",{0}", CrLf);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="primary"></param>
    private void ProcessPrimary(XElement primary) {
      builder.AppendFormat("  ");
      builder.AppendFormat("PRIMARY KEY (");
      primary.Value
             .Split(',')
             .ToList()
             .ForEach(key => builder.AppendFormat("`{0}`,", key.Trim()));
      builder.Remove(builder.Length - 1, 1);
      builder.AppendFormat("),{0}", CrLf);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="constraint"></param>
    private void ProcessConstraint(XElement constraint) {
      Constraint c = (Constraint)Enum.Parse(typeof(Constraint), constraint.Attribute("type").Value);

      builder.AppendFormat("  ");
      switch (c) {
        case Constraint.PK:
          builder.AppendFormat("PRIMARY KEY (`{0}`)", constraint.Parent.Attribute("name").Value);
          break;
        case Constraint.FK:
        case Constraint.CK:
          builder.AppendFormat("CONSTRAINT `fk_{0}_{1}_{2}_{3}`",
            constraint.Ancestors("table").FirstOrDefault().Attribute("name").Value,
            constraint.Parent.Attribute("name").Value,
            constraint.Attribute("table").Value,
            constraint.Attribute("field").Value);
          builder.AppendFormat(" FOREIGN KEY (`{0}`)", constraint.Parent.Attribute("name").Value);
          builder.AppendFormat(" REFERENCES `{0}` (`{1}`)",
            constraint.Attribute("table").Value, constraint.Attribute("field").Value);

          // RESTRICT | CASCADE | SET NULL | NO ACTION
          if (constraint.Attribute("cascade") != null && constraint.Attribute("cascade").Value == "true") {
            builder.AppendFormat(" ON DELETE CASCADE");
            builder.AppendFormat(" ON UPDATE NO ACTION");
          }
          else if (constraint.Attribute("setnull") != null && constraint.Attribute("setnull").Value == "true") {
            builder.AppendFormat(" ON DELETE SET NULL");
            builder.AppendFormat(" ON UPDATE NO ACTION");
          }
          else {
            builder.AppendFormat(" ON DELETE RESTRICT");
            builder.AppendFormat(" ON UPDATE NO ACTION");
          }
          break;
      }

      builder.AppendFormat(",{0}", CrLf);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    private void ProcessIndex(XElement index) {
      builder.AppendFormat("CREATE INDEX `idx_{0}_{1}`",
        index.Parent.Attribute("name").Value, index.Attribute("name").Value);
      builder.AppendFormat(" ON `{0}`", index.Parent.Attribute("name").Value);
      builder.AppendFormat(" (`{0}` ASC);{1}", index.Attribute("name").Value, CrLf);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="table"></param>
    /// <param name="value"></param>
    private void Insert(XElement table, XElement value) {
      builder.AppendFormat("INSERT INTO `{0}` (", table.Attribute("name").Value);
      foreach (var field in table.Elements("field")) {
        builder.AppendFormat("`{0}`,", field.Attribute("name").Value);
      }
      builder.Remove(builder.Length - 1, 1);
      builder.AppendFormat(") VALUES ({0});{1}", value.Value, CrLf);
    }
  }
}
