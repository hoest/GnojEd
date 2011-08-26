namespace GnojEd.Engine.Modules {
  using System;
  using System.Reflection;
  using GnojEd.Engine.Controller;
  using GnojEd.Engine.Data;
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
          try {
            var servername = p.HttpContext.Request.ServerVariables["server_name"];
            string viewAka = this.GetView(servername);
            var controller = ControllerService.GetController("page");
            var list = controller.ReadAll();
            return Render("default/default", list);
          }
          catch (ReflectionTypeLoadException rtle) {
            var ex = String.Empty;

            foreach (var le in rtle.LoaderExceptions) {
              ex = String.Format("{0}<br />{1}", ex, le.Message);
            }

            return ex;
          }
        });

      Get(
        "/:type/:id/:slug",
        p => {
          var servername = p.HttpContext.Request.ServerVariables["server_name"];
          string viewAka = this.GetView(servername);
          var controller = ControllerService.GetController((string)p.type);
          int id = -1;
          int.TryParse(p.id, out id);
          var model = controller.Read(id);
          return Render(String.Format("{0}/{1}", viewAka, p.type), model);
        });
    }

    /// <summary>
    /// GetView method, to return a string value based on the url
    /// </summary>
    /// <param name="url">String object of the url, mostly only the domainname, without http://</param>
    /// <returns>The alias of the view</returns>
    private string GetView(string url) {
      DBFactory db = new DBFactory();
      var view = db.DB().View.FindByUrl(url);

      string viewAka = String.Empty;
      if (view == null) {
        viewAka = "default";
      }
      else {
        viewAka = view.Aka;
      }

      return viewAka;
    }
  }
}
