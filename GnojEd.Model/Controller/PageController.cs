namespace GnojEd.Model.Controller {
  using System;
  using System.Collections.Generic;
  using System.Collections.Specialized;
  using GnojEd.Engine.Controller;
  using GnojEd.Engine.Data;
  using GnojEd.Engine.Model;
  using GnojEd.Model.Model;

  /// <summary>
  /// PageController class
  /// </summary>
  public class PageController : IController {
    /// <summary>
    /// DBFactory object
    /// </summary>
    private DBFactory db = new DBFactory();

    /// <summary>
    /// Create method
    /// </summary>
    /// <param name="form">NameValueCollection object</param>
    public void Create(NameValueCollection form) {
      Page page = new Page();
      this.db.DB().Page.Insert(page);
    }

    /// <summary>
    /// Read method
    /// </summary>
    /// <param name="id">Unique identifier</param>
    /// <returns>IModel model</returns>
    public IModel Read(int id) {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Read all method
    /// </summary>
    /// <returns>List of IModel model</returns>
    public IEnumerable<IModel> Read() {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Update method
    /// </summary>
    /// <param name="form">NameValueCollection object</param>
    public void Update(NameValueCollection form) {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Delete method
    /// </summary>
    /// <param name="id">Unique identifier</param>
    public void Delete(int id) {
      throw new NotImplementedException();
    }
  }
}
