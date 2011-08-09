namespace GnojEd.Engine.Shared {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using GnojEd.Engine.Extensions;

  /// <summary>
  /// Reflection class
  /// </summary>
  public class Reflection {
    /// <summary>
    /// Get all types
    /// </summary>
    /// <param name="type">Type object</param>
    /// <returns>IEnumerable of Type objects</returns>
    public static IEnumerable<Type> GetTypes(Type type) {
      List<Type> types = new List<Type>();

      AppDomain.CurrentDomain.GetAssemblies().ForEach(asm => {
        types.AddRange(asm.GetTypes().Where(t => t.GetInterface(type.FullName) != null));
      });

      return types;
    }

    /// <summary>
    /// Get a specific type
    /// </summary>
    /// <typeparam name="T">Type of a class</typeparam>
    /// <param name="className">Name of the class</param>
    /// <returns>Type object</returns>
    public static Type GetType<T>(string className) {
      var types = GetTypes(typeof(T));
      var type = types.Where(t => t.FullName.ToLowerInvariant() == className.ToLowerInvariant()).FirstOrDefault();
      return type;
    }

    /// <summary>
    /// Does this Type exists?
    /// </summary>
    /// <typeparam name="T">Type of class</typeparam>
    /// <param name="className">Name of the class</param>
    /// <returns>Boolean object</returns>
    public static bool HasType<T>(string className) {
      var type = GetType<T>(className);
      return type != null;
    }

    /// <summary>
    /// Activate the constructor of the given class
    /// </summary>
    /// <typeparam name="T">Type of the class</typeparam>
    /// <param name="className">Name of the class</param>
    /// <returns>Object of the given class</returns>
    public static T Activate<T>(string className) {
      var type = GetType<T>(className);
      return (T)Activator.CreateInstance(type);
    }
  }
}
