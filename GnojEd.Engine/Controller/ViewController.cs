﻿namespace GnojEd.Engine.Controller {
  using System;
  using System.Collections.Generic;
  using System.Collections.Specialized;
  using GnojEd.Engine.Data;
  using GnojEd.Engine.Model;

  /// <summary>
  /// ViewController class
  /// </summary>
  public class ViewController : IController {
    /// <summary>
    /// DBFactory object
    /// </summary>
    private DBFactory db = new DBFactory();

    /// <summary>
    /// Create method
    /// </summary>
    /// <param name="form">NameValueCollection object</param>
    public void Create(NameValueCollection form) {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Read method
    /// </summary>
    /// <param name="id">Id of the model-item</param>
    /// <returns>A IModel object</returns>
    public IModel Read(int id) {
      return (View)this.db.DB().View.FindById(id);
    }

    /// <summary>
    /// Read method; read all items
    /// </summary>
    /// <returns>IEnumerable of IModel objects</returns>
    public IEnumerable<IModel> ReadAll() {
      return this.db.DB().View.All().ToList<View>();
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
    /// <param name="id">Id of the model-item</param>
    public void Delete(int id) {
      this.db.DB().View.DeleteById(id);
    }
  }
}
