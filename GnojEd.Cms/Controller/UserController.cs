namespace GnojEd.Cms.Controller {
  using System;
  using System.Collections.Generic;
  using GnojEd.Cms.Model;

  public class UserController : IController {
    public IEnumerable<IModel> ListAll() {
      return new List<User>();
    }

    public IModel Single(int id) {
      throw new NotImplementedException();
    }

    public void Create(IModel model) {
      throw new NotImplementedException();
    }

    public void Update(IModel model) {
      throw new NotImplementedException();
    }

    public void Delete(IModel model) {
      throw new NotImplementedException();
    }
  }
}
