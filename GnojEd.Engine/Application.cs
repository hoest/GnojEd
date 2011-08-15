namespace GnojEd.Engine {
  using System;
  using System.Web;
  using GnojEd.Engine.Shared;
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
      Jess.Error((ex, req, type) => {
        var error = new Error() {
          Message = ex.Message,
          StackTrace = ex.StackTrace,
          Url = req.HttpContext.Request.Url.AbsolutePath
        };

        return Jess.Render("error/default", error);
      });

      Jess.Initialise();
    }
  }
}
