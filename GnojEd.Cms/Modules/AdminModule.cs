namespace GnojEd.Cms.Modules {
  using System;
  using GnojEd.Cms.Model;
  using Jessica;
  using Jessica.Responses;
  using GnojEd.Cms.Shared;
  using GnojEd.Cms.Controller;
  using System.Collections.Generic;

  /// <summary>
  /// 
  /// </summary>
  public class AdminModule : JessModule {
    /// <summary>
    /// 
    /// </summary>
    public AdminModule()
      : base("/admin") {
      //Before += Authentication.Authenticate();
      InitGet();
      InitPost();
    }

    /// <summary>
    /// 
    /// </summary>
    private void InitGet() {
      //// GET : List of objects from database
      Get("/:type", p => {
        return List(p);
      });

      //// GET : Create object
      Get("/:type/create", p => {
        return View(p.type);
      });

      //// List one objects from database
      Get("/:type/:id", p => {
        return Read(p);
      });

      //// GET : Update object
      Get("/:type/:id/update", p => {
        var controller = ControllerService.GetController((string)p.type);
        var item = (IModel)controller.Single(p.id);

        return View(p.type, item);
      });
    }

    /// <summary>
    /// 
    /// </summary>
    private void InitPost() {
      //// POST : Create object
      Post("/:type/create", p => {
        return Create(p);
      });

      //// POST : Update object
      Post("/:type/:id/update", p => {
        return Update(p);
      });

      //// POST : Delete object
      Post("/:type/:id/delete", p => {
        return Delete(p);
      });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    private Response List(dynamic p) {
      var controller = ControllerService.GetController((string)p.type);
      IEnumerable<IModel> list = controller.ListAll();

      return View(p.type, list);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    private Response Create(dynamic p) {
      var controller = ControllerService.GetController((string)p.type);

      //// Fill properties from post-data
      IModel item = null;
      controller.Create(item);

      return Response.AsRedirect(p.HttpContext.Request.UrlReferrer);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    private Response Read(dynamic p) {
      var controller = ControllerService.GetController((string)p.type);

      //// Get object-data
      var item = controller.Single(p.id);

      return View(p.type, item);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    private Response Update(dynamic p) {
      var controller = ControllerService.GetController((string)p.type);

      //// Get object-data
      var item = controller.Single(p.id);

      //// Fill properties from post-data
      controller.Update(item);

      return Response.AsRedirect(p.HttpContext.Request.UrlReferrer);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    private Response Delete(dynamic p) {
      var controller = ControllerService.GetController((string)p.type);

      //// Get object-data
      var item = controller.Single(p.id);

      //// Delete item
      controller.Delete(item);

      return Response.AsRedirect(p.HttpContext.Request.UrlReferrer);
    }
  }
}
