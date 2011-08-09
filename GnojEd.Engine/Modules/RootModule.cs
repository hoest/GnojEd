namespace GnojEd.Engine.Modules {
  using Jessica;
  using Jessica.Responses;

  /// <summary>
  /// RootModule class
  /// </summary>
  public class RootModule : JessModule {
    /// <summary>
    /// Initializes a new instance of the RootModule class
    /// </summary>
    public RootModule() {
      Get(
        "/",
        p => {
          return Response.AsRedirect("/show");
        });
    }
  }
}
