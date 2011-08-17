namespace GnojEd.Engine.Model {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  /// <summary>
  /// Page class
  /// </summary>
  public class Page : IModel {
    /// <summary>
    /// Gets or sets the Id
    /// </summary>
    public int Id {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the SiteId
    /// </summary>
    public int SiteId {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the CreatorId
    /// </summary>
    public int CreatorId {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the EditorId
    /// </summary>
    public int EditorId {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the Title
    /// </summary>
    public string Title {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the Slug
    /// </summary>
    public string Slug {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the Aka
    /// </summary>
    public string Aka {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the Created
    /// </summary>
    public DateTime Created {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the Modified
    /// </summary>
    public DateTime Modified {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the Summary
    /// </summary>
    public string Summary {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the Introduction
    /// </summary>
    public string Introduction {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the Text
    /// </summary>
    public string Text {
      get;
      set;
    }
  }
}
