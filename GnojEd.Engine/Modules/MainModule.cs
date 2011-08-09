namespace GnojEd.Engine.Modules {
  using GnojEd.Engine.Controller;
  using GnojEd.Engine.Model;
  using Jessica;

  /// <summary>
  /// MainModule class
  /// </summary>
  public class MainModule : JessModule {
    /// <summary>
    /// Initializes a new instance of the MainModule class
    /// </summary>
    public MainModule()
      : base("/show") {
      Get(
        "/",
        p => {
          // servername prop
          var servername = p.HttpContext.Request.ServerVariables["server_name"];
          return "Welcome at " + servername;
        });

      Get(
        "/:type/:id/:title",
        p => {
          // servername prop
          var controller = ControllerService.GetController((string)p.type);
          int id = -1;
          IModel model = null;
          if (int.TryParse(p.id, out id)) {
            model = controller.Read(id);
          }

          return View(p.type, model);
        });
    }
  }
}
