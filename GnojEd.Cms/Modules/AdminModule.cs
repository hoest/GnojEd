namespace GnojEd.Cms.Modules {
  using System;
  using GnojEd.Cms.Shared;
  using Jessica;
  using Jessica.Responses;

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

      Get("/site", Site());
      Get("/site/:id", SiteById());
      Get("/page", Page());
      Get("/page/:id", PageById());
      Get("/blog", Blog());
      Get("/blog/:id", BlogById());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static Func<dynamic, Response> Site() {
      return p => {
        return "Site";
      };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static Func<dynamic, Response> SiteById() {
      return p => {
        return String.Format("Site : {0}", p.id);
      };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static Func<dynamic, Response> Page() {
      return p => {
        return "Page";
      };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static Func<dynamic, Response> PageById() {
      return p => {
        return String.Format("Page : {0}", p.id);
      };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static Func<dynamic, Response> Blog() {
      return p => {
        return "Blog";
      };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static Func<dynamic, Response> BlogById() {
      return p => {
        return String.Format("Blog : {0}", p.id);
      };
    }
  }
}
