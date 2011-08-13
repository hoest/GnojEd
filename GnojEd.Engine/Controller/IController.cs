namespace GnojEd.Engine.Controller {
  using System.Collections.Generic;
  using System.Collections.Specialized;
  using GnojEd.Engine.Model;

  /// <summary>
  /// IController interface
  /// </summary>
  public interface IController {
    /// <summary>
    /// Create method
    /// </summary>
    /// <param name="form">NameValueCollection object</param>
    void Create(NameValueCollection form);

    /// <summary>
    /// Read method
    /// </summary>
    /// <param name="id">Id of the model-item</param>
    /// <returns>IModel object</returns>
    IModel Read(int id);

    /// <summary>
    /// Read method; read all items
    /// </summary>
    /// <returns>IEnumerable of IModel objects</returns>
    IEnumerable<IModel> Read();

    /// <summary>
    /// Update method
    /// </summary>
    /// <param name="form">NameValueCollection object</param>
    void Update(NameValueCollection form);

    /// <summary>
    /// Delete method
    /// </summary>
    /// <param name="id">Id of the model-item</param>
    void Delete(int id);
  }
}
