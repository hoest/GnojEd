namespace GnojEd.Engine.Modules {
  using System.Collections.Generic;
  using GnojEd.Engine.Controller;
  using GnojEd.Engine.Model;
  using Jessica;
  using Jessica.Responses;

  /// <summary>
  /// AdminModule class
  /// </summary>
  public class AdminModule : JessModule {
    /// <summary>
    /// Initializes a new instance of the AdminModule class
    /// </summary>
    public AdminModule()
      : base("/admin") {
      ////Before += Authentication.Authenticate();
      this.InitGet();
      this.InitPost();
    }

    /// <summary>
    /// Initialise the Get routes
    /// </summary>
    private void InitGet() {
      //// GET : List of objects from database
      Get(
        "/:type",
        p => {
          return List(p);
        });

      //// GET : Create object
      Get(
        "/:type/create",
        p => {
          return View(p.type);
        });

      //// List one objects from database
      Get(
        "/:type/:id",
        p => {
          return Read(p);
        });

      //// GET : Update object
      Get(
        "/:type/:id/update",
        p => {
          var controller = ControllerService.GetController((string)p.type);
          var item = (IModel)controller.Read(p.id);

          return View(p.type, item);
        });
    }

    /// <summary>
    /// Initialize the Post routes
    /// </summary>
    private void InitPost() {
      //// POST : Create object
      Post(
        "/:type/create",
        p => {
          return Create(p);
        });

      //// POST : Update object
      Post(
        "/:type/:id/update",
        p => {
          return Update(p);
        });

      //// POST : Delete object
      Post(
        "/:type/:id/delete",
        p => {
          return Delete(p);
        });
    }

    /// <summary>
    /// List of objects from database
    /// </summary>
    /// <param name="p">dynamic object</param>
    /// <returns>Jessica Response object</returns>
    private Response List(dynamic p) {
      var controller = ControllerService.GetController((string)p.type);
      IEnumerable<IModel> list = controller.Read();

      return View(p.type, list);
    }

    /// <summary>
    /// Create object
    /// </summary>
    /// <param name="p">dynamic object</param>
    /// <returns>Jessica Response object</returns>
    private Response Create(dynamic p) {
      var controller = ControllerService.GetController((string)p.type);

      //// Fill properties from post-data
      IModel item = null;
      controller.Create(item);

      return Response.AsRedirect(p.HttpContext.Request.UrlReferrer);
    }

    /// <summary>
    /// List one objects from database
    /// </summary>
    /// <param name="p">dynamic object</param>
    /// <returns>Jessica Response object</returns>
    private Response Read(dynamic p) {
      var controller = ControllerService.GetController((string)p.type);

      //// Get object-data
      var item = controller.Read(p.id);

      return View(p.type, item);
    }

    /// <summary>
    /// Update the object
    /// </summary>
    /// <param name="p">dynamic object</param>
    /// <returns>Jessica Response object</returns>
    private Response Update(dynamic p) {
      var controller = ControllerService.GetController((string)p.type);

      //// Get object-data
      var item = controller.Read(p.id);

      //// Fill properties from post-data
      controller.Update(item);

      return Response.AsRedirect(p.HttpContext.Request.UrlReferrer);
    }

    /// <summary>
    /// Delete the object
    /// </summary>
    /// <param name="p">dynamic object</param>
    /// <returns>Jessica Response object</returns>
    private Response Delete(dynamic p) {
      var controller = ControllerService.GetController((string)p.type);

      //// Get object-data
      var item = controller.Read(p.id);

      //// Delete item
      controller.Delete(item);

      return Response.AsRedirect(p.HttpContext.Request.UrlReferrer);
    }
  }
}
