namespace GnojEd.Cms.Model {
  using System;
  using System.Collections.Generic;
  using GnojEd.Cms.Shared;

  /// <summary>
  /// 
  /// </summary>
  public class ModelService {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="className"></param>
    /// <returns></returns>
    public static IModel GetController(string className) {
      string fullClassName = String.Format("{0}.{1}", "GnojEd.Cms.Model", className);

      if (Reflection.HasType<IModel>(fullClassName)) {
        return Reflection.Activate<IModel>(fullClassName);
      }
      else {
        throw new ModelNotFoundException(String.Format("Model not found for '{0}'", className));
      }
    }
  }
}
