using AutoMapper;
using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Entities;
using Lamazon.Services.Interfaces;
using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public UserViewModel GetUserById(int id)
        {
            var user = _userRepository.GetById(id);

            return _mapper.Map<UserViewModel>(user);
        }

        public UserViewModel RegisterUser(RegisterUserViewModel registerUserViewModel)
        {
            var user = _mapper.Map<User>(registerUserViewModel);

        }

        public UserViewModel ValidateUser(UserCredentialsViewModel userCredentialsViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
