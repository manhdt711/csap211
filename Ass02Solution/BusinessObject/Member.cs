using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Member
    {

        private int _memberID;
        public int MemberID
        {
            get => _memberID;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MemberID must be greater than 0");
                }
                _memberID = value;
            }
        }

        private string _companyName;
        public string CompanyName
        {
            get => _companyName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("MemberName cannot be null or empty");
                }
                _companyName = value;
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email cannot be null or empty");
                }
                if (!value.Contains("@") || !value.Contains("."))
                {
                    throw new ArgumentException("Email format is invalid");
                }
                _email = value;
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Password cannot be null or empty");
                }
                if (value.Length < 6)
                {
                    throw new ArgumentException("Password must be at least 6 characters long");
                }
                _password = value;
            }
        }

        private string _city;
        public string City
        {
            get => _city;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("City cannot be null or empty");
                }
                _city = value;
            }
        }

        private string _country;

        public string Country
        {
            get => _country;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Country cannot be null or empty");
                }
                _country = value;
            }
        }
    }
}

