namespace GnojEd.Sql {
  using System;
  using System.IO;
  using System.Linq;
  using System.Xml.Linq;

  /// <summary>
  /// Program class
  /// </summary>
  public class Program {
    /// <summary>
    /// Main method
    /// </summary>
    /// <param name="args">Arguments string array</param>
    public static void Main(string[] args) {
      if (args.Length != 1 && !String.IsNullOrEmpty(args[0])) {
        throw new ArgumentNullException("databaseXmlScheme");
      }

      string dataschemeFile = args[0];
      string sqlFile = Path.ChangeExtension(dataschemeFile, "sql");

      Console.WriteLine("Database XML file loaded");
      XDocument datascheme = XDocument.Load(dataschemeFile);

      IDataScheme scheme = new MySqlScheme();
      if (scheme != null) {
        Console.WriteLine("Created a IDataScheme");

        scheme.Init(datascheme.Root);

        var tables = datascheme.Descendants("table").ToList();
        tables.ForEach(table => scheme.ProcessTable(table));

        scheme.Ready();

        Console.WriteLine("Created SQL-file for {0} tables", tables.Count());

        if (File.Exists(sqlFile)) {
          Console.WriteLine("Delete existing SQL file");
          File.Delete(sqlFile);
        }

        using (StreamWriter writer = File.CreateText(sqlFile)) {
          Console.WriteLine("Save to SQL file");
          writer.Write(scheme.Result);
          writer.Close();
        }
      }
    }
  }
}
