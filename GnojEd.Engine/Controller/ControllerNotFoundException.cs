namespace GnojEd.Engine.Controller {
  using System;
  using GnojEd.Engine.Shared;

  /// <summary>
  /// ControllerNotFoundException class
  /// </summary>
  public class ControllerNotFoundException : GnojEdException {
    /// <summary>
    /// Initializes a new instance of the ControllerNotFoundException class
    /// </summary>
    public ControllerNotFoundException() {
    }

    /// <summary>
    /// Initializes a new instance of the ControllerNotFoundException class
    /// </summary>
    /// <param name="message">string message object</param>
    public ControllerNotFoundException(string message)
      : base(message) {
    }

    /// <summary>
    /// Initializes a new instance of the ControllerNotFoundException class
    /// </summary>
    /// <param name="message">string message object</param>
    /// <param name="e">Exception object</param>
    public ControllerNotFoundException(string message, Exception e)
      : base(message, e) {
    }
  }
}
