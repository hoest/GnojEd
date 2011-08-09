namespace GnojEd.Cms.Controller {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using GnojEd.Cms.Model;

  /// <summary>
  /// 
  /// </summary>
  public interface IController {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerable<IModel> ListAll();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    IModel Single(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    void Create(IModel model);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    void Update(IModel model);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    void Delete(IModel model);
  }
}
