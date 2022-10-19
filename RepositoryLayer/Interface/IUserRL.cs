using CommonLayer.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public UserRegistrationModel UserRegistration(UserRegistrationModel registrationModel);
    }
}
