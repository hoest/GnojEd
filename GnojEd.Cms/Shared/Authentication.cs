namespace GnojEd.Cms.Shared {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Web.Routing;
  using Jessica.Responses;

  /// <summary>
  /// 
  /// </summary>
  public class Authentication {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal static Func<RequestContext, Response> Authenticate() {
      return p => {
        if (p.HttpContext.Request.IsAuthenticated && p.HttpContext.User != null) {
          return null;
        }
        else {
          return Response.AsRedirect("/authentication/login");
        }
      };
    }
  }
}
