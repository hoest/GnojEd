namespace GnojEd.Engine.Model {
  using System;
  using GnojEd.Engine.Shared;

  /// <summary>
  /// ModelNotFoundException class
  /// </summary>
  public class ModelNotFoundException : GnojEdException {
    /// <summary>
    /// Initializes a new instance of the ModelNotFoundException class
    /// </summary>
    public ModelNotFoundException() {
    }

    /// <summary>
    /// Initializes a new instance of the ModelNotFoundException class
    /// </summary>
    /// <param name="message">string message object</param>
    public ModelNotFoundException(string message)
      : base(message) {
    }

    /// <summary>
    /// Initializes a new instance of the ModelNotFoundException class
    /// </summary>
    /// <param name="message">string message object</param>
    /// <param name="e">Exception object</param>
    public ModelNotFoundException(string message, Exception e)
      : base(message, e) {
    }
  }
}
