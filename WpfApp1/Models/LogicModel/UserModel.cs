﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models.LogicModel
{
    class UserModel
    {
        private Bookingdb bookingdb = new Bookingdb();
        public bool SignUp(string firstName, string lastName, string phoneNumber, string email, string address, string password)
        {
            var query = (from user in bookingdb.Users select user)?.ToList();
            foreach (var userInList in query)
            {
                if (userInList.Email.Contains(email))
                {
                    return false;
                }
            }

            bookingdb.Users.Add(new User()
            {
                First_Name = firstName,
                Last_Name = lastName,
                Email = email,
                Address = address,
                Phone = phoneNumber,
                Password = password,
                Role = "Customer"


            });
            bookingdb.SaveChanges();

            return true;
        }

        public bool SignIn(string email, string password)
        {
            try
            {
                var query = (from user in bookingdb.Users
                             where user.Email.Equals(email) && user.Password.Equals(password)
                             select user).First();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
