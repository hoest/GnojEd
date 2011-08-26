namespace GnojEd.Engine.ViewEngine {
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.IO;
  using System.Web;
  using Jessica.ViewEngine;
  using RazorEngine;

  /// <summary>
  /// RazorViewEngine class
  /// </summary>
  public class RazorViewEngine : IViewEngine {
    /// <summary>
    /// Initializes a new instance of the RazorViewEngine class
    /// </summary>
    public RazorViewEngine() {
      if (this.Cache == null) {
        this.Cache = new Hashtable();
      }
    }

    /// <summary>
    /// Gets the list of extensions used 
    /// </summary>
    public IEnumerable<string> Extensions {
      get {
        return new[] { "cshtml", "csrzr" };
      }
    }

    /// <summary>
    /// Gets or sets the viewlocation
    /// </summary>
    public ViewLocation ViewLocation {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the cache
    /// </summary>
    public Hashtable Cache {
      get;
      set;
    }

    /// <summary>
    /// RenderView method
    /// </summary>
    /// <param name="viewLocation">ViewLocation object</param>
    /// <param name="model">dynamic model object</param>
    /// <returns>Action object</returns>
    public Action<Stream> RenderView(ViewLocation viewLocation, dynamic model) {
      return stream => {
        this.ViewLocation = viewLocation;

        if (!this.Cache.ContainsKey(viewLocation.Location)) {
          string template = File.ReadAllText(viewLocation.Location);
          Razor.AddResolver(name => GetTemplate(name));
          Razor.CompileWithAnonymous(template, viewLocation.Location);
          this.Cache.Add(viewLocation.Location, DateTime.Now);
        }

        string result = Razor.Run(model, viewLocation.Location);

        var writer = new StreamWriter(stream);
        writer.Write(result);
        writer.Flush();
      };
    }

    /// <summary>
    /// GetTemplate method
    /// </summary>
    /// <param name="name">Name of the view to include</param>
    /// <returns>String of the razor template</returns>
    private string GetTemplate(string name) {
      string templateFile = HttpContext.Current.Server.MapPath(name);
      if (File.Exists(templateFile)) {
        return File.ReadAllText(templateFile);
      }

      return String.Empty;
    }
  }
}
