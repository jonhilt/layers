using System.Collections.Generic;
using Layers.Models;

namespace Layers.Repositories
{
    public interface IUserRepository
    {
        List<User> List();
    }

    public class UserRepository : IUserRepository
    {
        public List<User> List()
        {
            {
                return new List<User>{
                    new User{
                        FirstName = "Bob",
                        LastName = "Smith",
                        LastLogin = new System.DateTime(2019,1,1),
                        Active = true
                    }
                };
            }
        }

    }
}