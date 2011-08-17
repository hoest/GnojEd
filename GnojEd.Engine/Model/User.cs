namespace GnojEd.Engine.Model {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  /// <summary>
  /// User class
  /// </summary>
  public class User : IModel {
    /// <summary>
    /// Gets or sets the Id
    /// </summary>
    public int Id {
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
    /// Gets or sets the Email
    /// </summary>
    public string Email {
      get;
      set;
    }
  }
}
