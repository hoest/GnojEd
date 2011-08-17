namespace GnojEd.Engine.Model {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  /// <summary>
  /// Tag (keyword) class
  /// </summary>
  public class Tag : IModel {
    /// <summary>
    /// Gets or sets the Id
    /// </summary>
    public int Id {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the Label
    /// </summary>
    public string Label {
      get;
      set;
    }
  }
}
