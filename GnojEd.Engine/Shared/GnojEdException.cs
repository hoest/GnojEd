namespace GnojEd.Engine.Shared {
  using System;

  /// <summary>
  /// GnojEdException class
  /// </summary>
  public class GnojEdException : Exception {
    /// <summary>
    /// Initializes a new instance of the GnojEdException class
    /// </summary>
    public GnojEdException() {
    }

    /// <summary>
    /// Initializes a new instance of the GnojEdException class
    /// </summary>
    /// <param name="message">string message object</param>
    public GnojEdException(string message)
      : base(message) {
    }

    /// <summary>
    /// Initializes a new instance of the GnojEdException class
    /// </summary>
    /// <param name="message">string message object</param>
    /// <param name="e">Exception object</param>
    public GnojEdException(string message, Exception e)
      : base(message, e) {
    }
  }
}
