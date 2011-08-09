namespace GnojEd.Engine.Shared {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Web.Routing;
  using Jessica.Responses;

  /// <summary>
  /// Authentication class
  /// </summary>
  public class Authentication {
    /// <summary>
    /// Function to check if a visitor is logged in
    /// </summary>
    /// <returns>Delegate object</returns>
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
