namespace GnojEd.Model.Model {
  using GnojEd.Engine.Model;
  using GnojEd.Model.Model.Shared;

  /// <summary>
  /// Article class
  /// </summary>
  public class Page : IModel {
    /// <summary>
    /// Gets or sets the meta object
    /// </summary>
    public Meta Meta {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the introduction
    /// </summary>
    public string Introduction {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the body text
    /// </summary>
    public string Text {
      get;
      set;
    }
  }
}
