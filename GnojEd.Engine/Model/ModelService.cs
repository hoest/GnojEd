namespace GnojEd.Engine.Model {
  using System;
  using GnojEd.Engine.Shared;

  /// <summary>
  /// ModelService class
  /// </summary>
  public class ModelService {
    /// <summary>
    /// GetModel method
    /// </summary>
    /// <param name="className">Name of the class</param>
    /// <returns>IModel object</returns>
    public static IModel GetModel(string className) {
      string fullClassName = String.Format("{0}.{1}", "GnojEd.Engine.Model", className);

      if (Reflection.HasType<IModel>(fullClassName)) {
        return Reflection.Activate<IModel>(fullClassName);
      }
      else {
        throw new ModelNotFoundException(String.Format("Model not found for '{0}'", className));
      }
    }
  }
}
