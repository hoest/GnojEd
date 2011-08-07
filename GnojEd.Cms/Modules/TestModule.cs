namespace GnojEd.Cms.Modules {
  using Jessica;

  /// <summary>
  /// Just a module to test JessicaFx
  /// </summary>
  public class TestModule : JessModule {
    /// <summary>
    /// Constructor
    /// </summary>
    public TestModule()
      : base("/test") {
      Get("/", p => "Test");
    }
  }
}
