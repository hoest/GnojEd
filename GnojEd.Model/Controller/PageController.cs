namespace GnojEd.Model.Controller {
  using System;
  using System.Collections.Generic;
  using System.Collections.Specialized;
  using GnojEd.Engine.Controller;
  using GnojEd.Engine.Data;
  using GnojEd.Engine.Model;
  using GnojEd.Model.Model;
  using GnojEd.Model.Model.Shared;

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
      User user = this.db.DB().User.FindByLogin("jelle");

      Meta meta = new Meta();
      meta.CreatorId = user.Id;
      meta.Created = DateTime.Now;
      meta.EditorId = user.Id;
      meta.Modified = DateTime.Now;
      meta.Aka = form["aka"];
      meta.Description = form["description"];
      meta.Title = form["title"];
      meta = this.db.DB().Meta.Insert(meta);

      Page page = new Page();
      page.MetaId = meta.Id;
      page.SiteId = 1;
      page.Introduction = form["introduction"];
      page.Text = form["text"];

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
      List<Page> all = this.db.DB().Page.All().ToList<Page>();
      ////foreach (var page in all) {
      ////  Meta meta = this.db.DB().Meta.FindById(page.MetaId);
      ////  page.Meta = meta;
      ////}

      return all;
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
