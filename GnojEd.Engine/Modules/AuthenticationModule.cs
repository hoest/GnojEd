﻿namespace GnojEd.Engine.Modules {
  using System;
  using GnojEd.Engine.Data;
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
          return LoginUser(p);
        });

      Post(
        "/login",
        p => {
          return LoginUser(p);
        });
    }

    /// <summary>
    /// Login the user
    /// </summary>
    /// <param name="p">dynamic object</param>
    /// <returns>Jessica Response object</returns>
    private Response LoginUser(dynamic p) {
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
    }
  }
}