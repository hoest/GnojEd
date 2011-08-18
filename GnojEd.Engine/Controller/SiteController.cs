namespace GnojEd.Engine.Controller {
  using System;
  using System.Collections.Generic;
  using System.Collections.Specialized;
  using GnojEd.Engine.Data;
  using GnojEd.Engine.Extensions;
  using GnojEd.Engine.Model;

  /// <summary>
  /// SiteController class
  /// </summary>
  public class SiteController : IController {
    /// <summary>
    /// DBFactory object
    /// </summary>
    private DBFactory db = new DBFactory();

    /// <summary>
    /// Create method
    /// </summary>
    /// <param name="form">NameValueCollection object</param>
    public void Create(NameValueCollection form) {
      var site = this.GetSiteObject(form);
      this.db.DB().Site.Insert(site);
    }

    /// <summary>
    /// Read method
    /// </summary>
    /// <param name="id">Id of the model-item</param>
    /// <returns>A IModel object</returns>
    public IModel Read(int id) {
      return (Site)this.db.DB().Site.FindById(id);
    }

    /// <summary>
    /// Read method; read all items
    /// </summary>
    /// <returns>IEnumerable of IModel objects</returns>
    public IEnumerable<IModel> ReadAll() {
      return this.db.DB().Site.All().ToList<Site>();
    }

    /// <summary>
    /// Update method
    /// </summary>
    /// <param name="form">NameValueCollection object</param>
    public void Update(NameValueCollection form) {
      var site = this.GetSiteObject(form);
      this.db.DB().Site.Update(site);
    }

    /// <summary>
    /// Delete method
    /// </summary>
    /// <param name="id">Id of the model-item</param>
    public void Delete(int id) {
      this.db.DB().Site.DeleteById(id);
    }

    /// <summary>
    /// GetSiteObject: Create a Site object from the form
    /// </summary>
    /// <param name="form">NameValueCollection object</param>
    /// <returns>Site object</returns>
    private Site GetSiteObject(NameValueCollection form) {
      Site site = new Site();
      
      int id = 0;
      if (!String.IsNullOrEmpty(form["Id"]) && int.TryParse(form["Id"], out id)) {
        site.Id = id;
      }

      site.Name = form.GetValue("Name");
      site.Aka = form.GetValue("Aka");

      int viewId = 0;
      if (!String.IsNullOrEmpty(form["ViewId"]) && int.TryParse(form["ViewId"], out viewId)) {
        site.ViewId = viewId;
      }

      return site;
    }
  }
}
