using System.Collections.Generic;
using Layers.Models;
using Layers.Repositories;

namespace Layers.Services
{
    public interface IUserService
    {
        List<User> ListAll();
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<User> ListAll()
        {
            return userRepository.List();
        }
    }

}