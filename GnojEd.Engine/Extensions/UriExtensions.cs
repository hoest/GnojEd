namespace GnojEd.Engine.Extensions {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Web;

  /// <summary>
  /// UriExtensions class
  /// </summary>
  public static class UriExtensions {
    /// <summary>
    /// AddQueryParam method
    /// </summary>
    /// <param name="uri">Uri uri object</param>
    /// <param name="key">String key object</param>
    /// <param name="value">String value object</param>
    /// <returns>An Uri with the new query-param added</returns>
    public static Uri AddQueryParam(this Uri uri, string key, string value) {
      var queryParams = HttpUtility.ParseQueryString(uri.Query, Encoding.UTF8);
      if (!String.IsNullOrEmpty(queryParams[key])) {
        queryParams.Remove(key);
      }

      queryParams.Add(key, value);
      var resultUri = new Uri(String.Format("{0}?{1}", uri.GetLeftPart(UriPartial.Path), queryParams));
      return resultUri;
    }
  }
}
