namespace GnojEd.Cms.Controller {
  using System;
  using GnojEd.Cms.Shared;

  public class ControllerNotFoundException : GnojEdException {
    public ControllerNotFoundException() {
    }

    public ControllerNotFoundException(string message)
      : base(message) {
    }

    public ControllerNotFoundException(string message, Exception e)
      : base(message, e) {
    }
  }
}
