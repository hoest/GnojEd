namespace GnojEd.Engine.Modules {
  using System.Collections.Generic;
  using GnojEd.Engine.Controller;
  using Jessica;
  using Jessica.Responses;

  /// <summary>
  /// JsonModule class
  /// </summary>
  public class JsonModule : JessModule {
    /// <summary>
    /// Initializes a new instance of the JsonModule class
    /// </summary>
    public JsonModule()
      : base("/json") {
      Get(
        "/:type",
        p => {
          var controller = ControllerService.GetController((string)p.type);
          var list = controller.ReadAll();
          return Response.AsJson(list);
        });

      Get(
        "/:type/:id",
        p => {
          var controller = ControllerService.GetController((string)p.type);

          //// Get object-data
          int id = -1;
          int.TryParse(p.id, out id);
          var item = controller.Read(id);
          return Response.AsJson(item);
        });
    }
  }
}
