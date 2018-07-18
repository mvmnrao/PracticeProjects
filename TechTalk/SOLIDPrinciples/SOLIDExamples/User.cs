using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExamples
{
    public class User
    {
        string _email;
        string _password;

        public User(string email, string password)
        {
            _email = email;
            _password = password;
        }
    }
}
