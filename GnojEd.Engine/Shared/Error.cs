namespace GnojEd.Engine.Shared {
  using System;

  /// <summary>
  /// Error class
  /// </summary>
  public class Error {
    /// <summary>
    /// Gets or sets the message
    /// </summary>
    public string Message {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the StackTrace
    /// </summary>
    public string StackTrace {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the Url
    /// </summary>
    public string Url {
      get;
      set;
    }
  }
}
