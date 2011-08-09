namespace GnojEd.Engine.Data {
  using System.Configuration;
  using System.Web;
  using Simple.Data;

  /// <summary>
  /// DBFactory class
  /// </summary>
  public class DBFactory : IDBFactory {
    /// <summary>
    /// Dynamic object
    /// </summary>
    private dynamic db = null;

    /// <summary>
    /// Initializes a new instance of the DBFactory class
    /// </summary>
    public DBFactory() {
    }

    /// <summary>
    /// Create a database connection, using Simple.Data
    /// </summary>
    /// <returns>Dynamic object</returns>
    public dynamic DB() {
      if (this.db == null) {
        var context = HttpContext.Current;
        var connectionString = ConfigurationManager.ConnectionStrings["DefaultDatabase"];

        if (string.IsNullOrWhiteSpace(connectionString.ConnectionString)) {
          return Database.OpenFile(context.Server.MapPath("~/App_data/GnojEd.sdf"));
        }
        else {
          return Database.OpenConnection(connectionString.ConnectionString);
        }
      }

      return this.db;
    }
  }
}
