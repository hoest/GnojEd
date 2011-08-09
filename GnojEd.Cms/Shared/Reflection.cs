namespace GnojEd.Cms.Shared {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using GnojEd.Cms.Extensions;

  /// <summary>
  /// 
  /// </summary>
  public class Reflection {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static IEnumerable<Type> GetTypes(Type type) {
      List<Type> types = new List<Type>();

      AppDomain.CurrentDomain.GetAssemblies().ForEach(asm => {
        types.AddRange(asm.GetTypes().Where(t => t.GetInterface(type.FullName) != null));
      });

      return types;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="className"></param>
    /// <returns></returns>
    public static Type GetType<T>(string className) {
      var types = GetTypes(typeof(T));
      var type = types.Where(t => t.FullName.ToLowerInvariant() == className.ToLowerInvariant()).FirstOrDefault();
      return type;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="className"></param>
    /// <returns></returns>
    public static bool HasType<T>(string className) {
      var type = GetType<T>(className);
      return type != null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="className"></param>
    /// <returns></returns>
    public static T Activate<T>(string className) {
      var type = GetType<T>(className);
      return (T)Activator.CreateInstance(type);
    }
  }
}
