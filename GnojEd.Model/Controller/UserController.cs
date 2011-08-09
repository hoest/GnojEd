namespace GnojEd.Model.Controller {
  using System;
  using System.Collections.Generic;
  using GnojEd.Engine.Controller;
  using GnojEd.Engine.Model;
  using GnojEd.Model.Model;

  /// <summary>
  /// UserController class
  /// </summary>
  public class UserController : IController {
    /// <summary>
    /// Read all users from DB
    /// </summary>
    /// <returns>IEnumerable of Users</returns>
    public IEnumerable<IModel> Read() {
      return new List<User>();
    }

    /// <summary>
    /// Read the User from the DB
    /// </summary>
    /// <param name="id">Unique identifier</param>
    /// <returns>IModel object of the User</returns>
    public IModel Read(int id) {
      User u = new User();
      u.Name = "Jelle de Jong";
      u.Login = "jelle";
      return u;
    }

    /// <summary>
    /// Create the user in the DB
    /// </summary>
    /// <param name="model">IModel object</param>
    public void Create(IModel model) {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Update the user in the DB
    /// </summary>
    /// <param name="model">IModel object</param>
    public void Update(IModel model) {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Delete the User from the DB
    /// </summary>
    /// <param name="model">IModel object</param>
    public void Delete(IModel model) {
      throw new NotImplementedException();
    }
  }
}
