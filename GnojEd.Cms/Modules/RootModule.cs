namespace GnojEd.Cms.Modules {
  using Jessica;
  using Jessica.Responses;
  using GnojEd.Cms.Shared;

  /// <summary>
  /// 
  /// </summary>
  public class RootModule : JessModule {
    /// <summary>
    /// 
    /// </summary>
    public RootModule() {
      Get("/", p => {
        return "Welcome";
      });
    }
  }
}
