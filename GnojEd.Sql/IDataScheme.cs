namespace GnojEd.Sql {
  using System.Xml.Linq;

  public interface IDataScheme {
    string Result {
      get;
    }

    void Init(XElement database);

    void ProcessTable(XElement table);

    void Ready();
  }
}
