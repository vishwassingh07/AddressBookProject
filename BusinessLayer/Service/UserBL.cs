using BusinessLayer.Interface;
using CommonLayer.Model.UserModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public UserRegistrationModel UserRegistration(UserRegistrationModel registrationModel)
        {
            try
            {
                return userRL.UserRegistration(registrationModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<UserRetrieveModel> GetAllAddress()
        {
            try
            {
                return userRL.GetAllAddress();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
