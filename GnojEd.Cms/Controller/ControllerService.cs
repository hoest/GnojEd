namespace GnojEd.Cms.Controller {
  using System;
  using System.Collections.Generic;
  using GnojEd.Cms.Shared;

  /// <summary>
  /// 
  /// </summary>
  public class ControllerService {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IController GetController(string className) {
      string fullClassName = String.Format("{0}.{1}Controller", "GnojEd.Cms.Controller", className);

      if (Reflection.HasType<IController>(fullClassName)) {
        return Reflection.Activate<IController>(fullClassName);
      }
      else {
        throw new ControllerNotFoundException(String.Format("Controller not found for '{0}'", className));
      }
    }
  }
}
