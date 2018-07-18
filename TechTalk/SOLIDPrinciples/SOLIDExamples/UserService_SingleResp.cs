using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace SOLIDExamples
{
    public class UserService
    {
        IDataBase _database;
        SmtpClient _smtpClient;
        EmailService _emailService;

        public UserService(IDataBase dataBase, SmtpClient smtpClient)
        {
            _database = dataBase;
            _smtpClient = smtpClient;
        }

        public void Register(string email, string password)
        {
            if (!_emailService.ValidateEmail("@"))
            {
                throw new ValidationException("Email is not valid!");
            }
            var user = new User(email, password);
            _database.Save(user);
            _emailService.SendEmail(new MailMessage("mysite@nowhere.com", email) { Subject = "Hello!" });
        } 
    }

    public class EmailService
    {
        SmtpClient _smtpClient;

        public bool ValidateEmail(string email)
        {
            return email.Contains("@");
        }
        public void SendEmail(MailMessage message)
        {
            _smtpClient.Send(message);
        }
    }
}
