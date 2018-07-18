using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExamples
{


    public interface ILogin
    {
        bool Login(string username, string password);
        void Logout(string username);
    }
    public interface IRegister
    {
        Guid Register(string username, string password, string email);
    }
    public interface IForgotPassword
    {
        void ForgotPassword(string username);
    }

    public interface IMembership : ILogin, IRegister, IForgotPassword
    {
    }

    public class RegisterUser : IRegister
    {
        public Guid Register(string username, string password, string email)
        {
            //My Implementation
            return new Guid();
        }
    }

    public class ForgotPass : IForgotPassword
    {
        public void ForgotPassword(string username)
        {
            //My implementation
        }
    }
}
