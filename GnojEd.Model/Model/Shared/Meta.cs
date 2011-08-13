namespace GnojEd.Model.Model.Shared {
  using System;
  using System.Collections.Generic;
  using GnojEd.Engine.Data;
  using GnojEd.Engine.Model;

  /// <summary>
  /// Meta class
  /// </summary>
  public class Meta : IModel {
    /// <summary>
    /// List of tags
    /// </summary>
    private List<Tag> tags = new List<Tag>();

    /// <summary>
    /// DBFactory object
    /// </summary>
    private DBFactory db = new DBFactory();

    /// <summary>
    /// Gets or sets the ID
    /// </summary>
    public uint Id {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the title
    /// </summary>
    public string Title {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the technical name (alias or 'also known as')
    /// </summary>
    public string Aka {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the date-created
    /// </summary>
    public DateTime Created {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the date-modified
    /// </summary>
    public DateTime Modified {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the user who created this item
    /// </summary>
    public uint CreatorId {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the user who last modified this item
    /// </summary>
    public uint EditorId {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the description
    /// </summary>
    public string Description {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the tags
    /// </summary>
    public List<Tag> Tags {
      get;
      set;
    }
  }
}
