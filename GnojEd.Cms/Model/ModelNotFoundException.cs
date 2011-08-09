namespace GnojEd.Cms.Model {
  using System;
  using GnojEd.Cms.Shared;

  public class ModelNotFoundException : GnojEdException {
    public ModelNotFoundException() {
    }

    public ModelNotFoundException(string message)
      : base(message) {
    }

    public ModelNotFoundException(string message, Exception e)
      : base(message, e) {
    }
  }
}
