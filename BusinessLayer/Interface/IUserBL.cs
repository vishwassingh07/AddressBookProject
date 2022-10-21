using CommonLayer.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserRegistrationModel UserRegistration(UserRegistrationModel registrationModel);
        public List<UserRetrieveModel> GetAllAddress();
    }
}
