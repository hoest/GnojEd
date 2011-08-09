namespace GnojEd.Cms.Extensions {
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// 
  /// </summary>
  public static class EnumerableExtensions {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="action"></param>
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action) {
      foreach (var item in collection) {
        action(item);
      }
    }
  }
}
