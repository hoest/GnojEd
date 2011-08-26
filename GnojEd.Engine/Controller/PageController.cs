namespace GnojEd.Engine.Controller {
  using System;
  using System.Collections.Generic;
  using System.Collections.Specialized;
using GnojEd.Engine.Data;
  using GnojEd.Engine.Model;

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
    }

    /// <summary>
    /// Read method
    /// </summary>
    /// <param name="id">Id of the model-item</param>
    /// <returns>A IModel object</returns>
    public IModel Read(int id) {
      return (Page)this.db.DB().Page.FindById(id);
    }

    /// <summary>
    /// Read method; read all items
    /// </summary>
    /// <returns>IEnumerable of IModel objects</returns>
    public IEnumerable<IModel> ReadAll() {
      return this.db.DB().Page.All().ToList<Page>();
    }

    /// <summary>
    /// Update method
    /// </summary>
    /// <param name="form">NameValueCollection object</param>
    public void Update(NameValueCollection form) {
    }

    /// <summary>
    /// Delete method
    /// </summary>
    /// <param name="id">Id of the model-item</param>
    public void Delete(int id) {
      this.db.DB().Page.DeleteById(id);
    }
  }
}
