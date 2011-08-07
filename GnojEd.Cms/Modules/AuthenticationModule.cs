namespace GnojEd.Cms.Modules {
  using System;
  using GnojEd.Cms.Data;
  using Jessica;
  using Jessica.Responses;

  /// <summary>
  /// 
  /// </summary>
  public class AuthenticationModule : JessModule {
    /// <summary>
    /// 
    /// </summary>
    public AuthenticationModule()
      : base("/authentication") {
      Get("/login", LoginUser());
      Post("/login", LoginUser());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static Func<dynamic, Response> LoginUser() {
      return p => {
        var db = new DBFactory();
        var user = db.DB().User.FindByLoginAndPassword("jelle", "123");

        if (user != null) {
          return user.FullName;
        }

        if (p.HttpContext.Request.IsAuthenticated && p.HttpContext.Request.UrlReferrer != null) {
          return Response.AsRedirect(p.HttpContext.Request.UrlReferrer);
        }
        else if (p.HttpContext.Request.IsAuthenticated) {
          return "Logged in";
        }
        else {
          return Response.AsRedirect("/authentication/login?invalid=true");
        }
      };
    }
  }
}
