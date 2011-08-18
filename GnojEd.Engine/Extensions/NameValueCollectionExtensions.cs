namespace GnojEd.Engine.Extensions {
  using System;
  using System.Collections.Specialized;

  /// <summary>
  /// NameValueCollectionExtensions class
  /// </summary>
  public static class NameValueCollectionExtensions {
    /// <summary>
    /// GetValue method: gets the value of the given key, or 'null' if its value
    /// is null or empty
    /// </summary>
    /// <param name="nvc">NameValueCollection nvc object</param>
    /// <param name="key">string key object</param>
    /// <returns>string value or 'null' if its value is null or empty</returns>
    public static string GetValue(this NameValueCollection nvc, string key) {
      if (!String.IsNullOrEmpty(nvc[key])) {
        return nvc[key];
      }
      else {
        return null;
      }
    }
  }
}
