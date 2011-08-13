namespace GnojEd.Model.Model.Shared {
  using GnojEd.Engine.Model;

  /// <summary>
  /// User class
  /// </summary>
  public class User : IModel {
    /// <summary>
    /// Gets or sets the unique identifier
    /// </summary>
    public uint Id {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the Login
    /// </summary>
    public string Login {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the Password
    /// </summary>
    public string Password {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the Name
    /// </summary>
    public string Name {
      get;
      set;
    }
  }
}
