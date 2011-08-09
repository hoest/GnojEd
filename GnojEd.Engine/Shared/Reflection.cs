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
    /// <param name="classPaths">IEnumerable of classpaths</param>
    /// <returns>IEnumerable of Type objects</returns>
    public static IEnumerable<Type> GetTypes(Type type, IEnumerable<string> classPaths) {
      List<Type> types = new List<Type>();

      AppDomain.CurrentDomain.GetAssemblies().ForEach(asm => {
        var asmTypes = from t in asm.GetTypes()
                       where classPaths.Contains(t.Namespace)
                       where t.GetInterface(type.Name) != null
                       select t;

        //// asm.GetTypes().Where(t => t.GetInterface(type.FullName) != null)
        types.AddRange(asmTypes);
      });

      return types;
    }

    /// <summary>
    /// Get a specific type
    /// </summary>
    /// <typeparam name="T">Type of a class</typeparam>
    /// <param name="className">Name of the class</param>
    /// <param name="classPaths">IEnumerable of classpaths</param>
    /// <returns>Type object</returns>
    public static Type GetType<T>(string className, IEnumerable<string> classPaths) {
      var types = GetTypes(typeof(T), classPaths);
      var type = types.Where(t => t.Name.ToLowerInvariant() == className.ToLowerInvariant()).FirstOrDefault();
      return type;
    }

    /// <summary>
    /// Does this Type exists?
    /// </summary>
    /// <typeparam name="T">Type of class</typeparam>
    /// <param name="className">Name of the class</param>
    /// <param name="classPaths">IEnumerable of classpaths</param>
    /// <returns>Boolean object</returns>
    public static bool HasType<T>(string className, IEnumerable<string> classPaths) {
      var type = GetType<T>(className, classPaths);
      return type != null;
    }

    /// <summary>
    /// Activate the constructor of the given class
    /// </summary>
    /// <typeparam name="T">Type of the class</typeparam>
    /// <param name="className">Name of the class</param>
    /// <param name="classPaths">IEnumerable of classpaths</param>
    /// <returns>Object of the given class</returns>
    public static T Activate<T>(string className, IEnumerable<string> classPaths) {
      var type = GetType<T>(className, classPaths);
      return (T)Activator.CreateInstance(type);
    }
  }
}
