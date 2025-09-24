using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel RegisterUser(RegisterUserViewModel registerUserViewModel);

        UserViewModel GetUserById(int id);

        UserViewModel ValidateUser(UserCredentialsViewModel userCredentialsViewModel);


    }
}
