﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model.UserModel
{
    public class UserRegistrationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
    }
}
