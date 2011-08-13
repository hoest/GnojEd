namespace GnojEd.Model.Model {
  using GnojEd.Engine.Data;
  using GnojEd.Engine.Model;
  using GnojEd.Model.Model.Shared;

  /// <summary>
  /// Article class
  /// </summary>
  public class Page : IModel {
    /// <summary>
    /// Unique identifier for the meta-object
    /// </summary>
    private int metaId = 0;

    /// <summary>
    /// DBFactory object
    /// </summary>
    private DBFactory db = new DBFactory();

    /// <summary>
    /// Gets or sets the unique identifier
    /// </summary>
    public int Id {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the unique identifier of the site
    /// </summary>
    public int SiteId {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the unique identifier of the site
    /// </summary>
    public int MetaId {
      get {
        return this.metaId;
      }

      set {
        this.metaId = value;
        this.Meta = this.db.DB().Meta.FindById(this.metaId);
      }
    }

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
