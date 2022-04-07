using BusinessLogicInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserLogic : IUserLogic
    {

        public IEnumerable<User> GetAll()
        {
            return null;
        }

        public bool IsLogued(string token)
        {
            //UserSession userSession = repository.GetAll().Where(x => x.Token == token).FirstOrDefault();
            return true;
        }

        public string LogIn(string nickname, string password)
        {
            var guid = Guid.NewGuid();
            return guid.ToString();
        }

        public void LogOut(string token)
        {
           
        }
    }
}
