using System;
using System.Collections.Generic;
using System.Linq;
namespace Training_Center_Task_15
{
    public class NewConsumerInfo
    {
        protected string newUserBaseUsername = "TestUser";
        protected string domain = "@email.com";
        protected string password = "123";

        protected string dateTimeNow = DateTime.Now.ToString();
        protected string address = "1 Main St.";
        protected string country = "United States";
        protected string state = "Nebraska";
        protected string city = "Omaha";
        protected string zipcode = "12345";
        protected string mobileNumber = "123456789";

        public string Username => newUserBaseUsername + dateTimeNow;
        public string Domain => domain;
        public string Email => Username.Replace(" ", "").Replace(":", "") + Domain;
        public string FirstName => Username + "_FN";
        public string LastName => Username + "_LN";
        public string Password => password;
        public string Address => address;
        public string Country => country;
        public string State => state;
        public string City => city;
        public string Zipcode => zipcode;
        public string MobileNumber => mobileNumber;
    }
}
