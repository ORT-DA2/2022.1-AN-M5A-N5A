using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicInterface
{
    public interface IUserLogic
    {
        IEnumerable<User> GetAll();
        string LogIn(string nickname, string password);
        void LogOut(string token);
        bool IsLogued(string token);
    }
}
