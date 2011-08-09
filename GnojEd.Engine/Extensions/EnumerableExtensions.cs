namespace GnojEd.Engine.Extensions {
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// EnumerableExtensions class
  /// </summary>
  public static class EnumerableExtensions {
    /// <summary>
    /// ForEach method for an IEnumerable
    /// </summary>
    /// <typeparam name="T">Type of class</typeparam>
    /// <param name="collection">IEnumerable object</param>
    /// <param name="action">Action object</param>
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action) {
      foreach (var item in collection) {
        action(item);
      }
    }
  }
}
