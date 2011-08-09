namespace GnojEd.Engine.Controller {
  using System;
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
      string fullClassName = String.Format("{0}.{1}Controller", "GnojEd.Engine.Controller", className);

      if (Reflection.HasType<IController>(fullClassName)) {
        return Reflection.Activate<IController>(fullClassName);
      }
      else {
        throw new ControllerNotFoundException(String.Format("Controller not found for '{0}'", className));
      }
    }
  }
}
