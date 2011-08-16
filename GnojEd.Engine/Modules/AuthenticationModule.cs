namespace GnojEd.Engine.Modules {
  using System;
  using System.Web;
  using System.Web.Security;
  using System.Xml.Linq;
  using GnojEd.Engine.Data;
  using GnojEd.Engine.Extensions;
  using Jessica;
  using Jessica.Responses;

  /// <summary>
  /// AuthenticationModule class
  /// </summary>
  public class AuthenticationModule : JessModule {
    /// <summary>
    /// Initializes a new instance of the AuthenticationModule class
    /// </summary>
    public AuthenticationModule()
      : base("/authentication") {
      Get(
        "/login",
        p => {
          var authenticated = new XElement("authenticated", p.HttpContext.Request.IsAuthenticated.ToString().ToLowerInvariant());
          return Render("authentication/login", authenticated);
        });

      Get(
        "/logout",
        p => {
          FormsAuthentication.SignOut();
          p.HttpContext.Session.Remove("user.name");
          p.HttpContext.Session.Remove("user.login");
          p.HttpContext.Session.Remove("user.id");

          return Render("authentication/logout");
        });

      Post(
        "/login",
        p => {
          var username = p.HttpContext.Request.Form["username"];
          var password = p.HttpContext.Request.Form["password"];
          var referrer = p.HttpContext.Request.Form["referrer"];

          if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(username)) {
            return LoginUser(p.HttpContext, username, password, referrer);
          }
          else {
            return Response.AsRedirect(String.Format("/authentication/login?ref={0}&login=false", referrer));
          }
        });
    }

    /// <summary>
    /// Login the user
    /// </summary>
    /// <param name="context">HttpContext object</param>
    /// <param name="username">Username property</param>
    /// <param name="password">Password property</param>
    /// <param name="referrer">Referrer property</param>
    /// <returns>Jessica Response object</returns>
    private Response LoginUser(HttpContext context, string username, string password, string referrer) {
      var db = new DBFactory();
      var user = db.DB().User.FindByLoginAndPassword(username, password.ToSHA512());

      if (user != null) {
        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(username, false, 15);
        var cookieStr = FormsAuthentication.Encrypt(ticket);
        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieStr);
        cookie.Path = FormsAuthentication.FormsCookiePath;
        context.Response.Cookies.Add(cookie);

        context.Session.Remove("user.name");
        context.Session.Add("user.name", user.Name);
        context.Session.Remove("user.login");
        context.Session.Add("user.login", user.Login);
        context.Session.Remove("user.id");
        context.Session.Add("user.id", String.Format("{0}", user.Id));

        return Response.AsRedirect(String.Format("{0}?login=true", referrer));
      }
      else {
        return Response.AsRedirect(String.Format("/authentication/login?ref={0}&invalid=true", referrer));
      }
    }
  }
}
