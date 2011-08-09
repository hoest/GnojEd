namespace GnojEd.Engine {
  using System;
  using System.Web;
  using Jessica;

  /// <summary>
  /// Global.asax HttpApplication implementation
  /// </summary>
  public class Application : HttpApplication {
    /// <summary>
    /// Code that runs on application startup
    /// </summary>
    /// <param name="sender">Sender object</param>
    /// <param name="e">EventArgs object</param>
    public void Application_Start(object sender, EventArgs e) {
      Jess.Initialise();
    }
  }
}
