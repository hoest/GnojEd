namespace GnojEd.Sql {
  using System.Xml.Linq;

  /// <summary>
  /// IDataScheme interface
  /// </summary>
  public interface IDataScheme {
    /// <summary>
    /// Gets the Result of all the actions
    /// </summary>
    string Result {
      get;
    }

    /// <summary>
    /// Initialize database scheme from XML
    /// </summary>
    /// <param name="database">Xml rootnode of scheme file</param>
    void Init(XElement database);

    /// <summary>
    /// ProcessTable method
    /// </summary>
    /// <param name="table">Xml table element</param>
    void ProcessTable(XElement table);

    /// <summary>
    /// Ready method
    /// </summary>
    void Ready();
  }
}
