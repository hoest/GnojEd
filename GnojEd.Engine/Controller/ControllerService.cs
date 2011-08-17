namespace GnojEd.Engine.Controller {
  using System;
  using System.Collections.Generic;
  using GnojEd.Engine.Shared;

  /// <summary>
  /// ControllerService class
  /// </summary>
  public class ControllerService {
    /// <summary>
    /// GetController method
    /// </summary>
    /// <param name="className">Name of the class</param>
    /// <returns>IController object</returns>
    public static IController GetController(string className) {
      var controllerPath = new List<string>() {
        "GnojEd.Engine.Controller"
      };

      className = String.Format("{0}Controller", className);

      if (Reflection.HasType<IController>(className, controllerPath)) {
        return Reflection.Activate<IController>(className, controllerPath);
      }
      else {
        throw new ControllerNotFoundException(String.Format("Controller not found for '{0}'", className));
      }
    }
  }
}
