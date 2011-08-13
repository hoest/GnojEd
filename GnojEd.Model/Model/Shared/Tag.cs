namespace GnojEd.Model.Model.Shared {
  using GnojEd.Engine.Model;

  /// <summary>
  /// Tag class definition
  /// </summary>
  public class Tag : IModel {
    /// <summary>
    /// Gets or sets the id
    /// </summary>
    public int Id {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the label of the tag
    /// </summary>
    public string Label {
      get;
      set;
    }
  }
}
