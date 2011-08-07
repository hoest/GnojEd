namespace GnojEd.Cms.Data {
  using System.Configuration;
  using System.Web;
  using Simple.Data;

  /// <summary>
  /// 
  /// </summary>
  public class DBFactory : IDBFactory {
    /// <summary>
    /// 
    /// </summary>
    public DBFactory() {
    }

    /// <summary>
    /// 
    /// </summary>
    protected dynamic _db = null;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public dynamic DB() {
      if (_db == null) {
        var context = HttpContext.Current;
        var connectionString = ConfigurationManager.ConnectionStrings["DefaultDatabase"];

        if (string.IsNullOrWhiteSpace(connectionString.ConnectionString)) {
          return Database.OpenFile(context.Server.MapPath("~/App_data/GnojEd.sdf"));
        }
        else {
          return Database.OpenConnection(connectionString.ConnectionString);
        }
      }

      return _db;
    }
  }
}
