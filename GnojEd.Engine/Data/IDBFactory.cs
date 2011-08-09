namespace GnojEd.Engine.Data {
  /// <summary>
  /// IDBFactory interface
  /// </summary>
  public interface IDBFactory {
    /// <summary>
    /// Gets the DB connection
    /// </summary>
    /// <returns>dynamic object</returns>
    dynamic DB();
  }
}
