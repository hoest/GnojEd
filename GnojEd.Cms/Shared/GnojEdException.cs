namespace GnojEd.Cms.Shared {
  using System;

  public class GnojEdException : Exception {
    public GnojEdException() {
    }

    public GnojEdException(string message)
      : base(message) {
    }

    public GnojEdException(string message, Exception e)
      : base(message, e) {
    }
  }
}
