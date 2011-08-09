namespace GnojEd.Engine.Modules {
  using Jessica;

  /// <summary>
  /// Just a module to test JessicaFx
  /// </summary>
  public class TestModule : JessModule {
    /// <summary>
    /// Initializes a new instance of the TestModule class
    /// </summary>
    public TestModule()
      : base("/test") {
      Get("/", p => "Test");
    }
  }
}
