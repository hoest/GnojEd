namespace GnojEd.Model.Model.Shared {
  using System;
  using System.Collections.Generic;
  using GnojEd.Engine.Model;

  /// <summary>
  /// Meta class
  /// </summary>
  public class Meta : IModel {
    /// <summary>
    /// Gets or sets the ID
    /// </summary>
    public int Id {
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
    public User Creator {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the user who last modified this item
    /// </summary>
    public User Editor {
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
    public IEnumerable<Tag> Tags {
      get;
      set;
    }
  }
}
