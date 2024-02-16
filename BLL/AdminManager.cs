using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdminManager
    {
        public DataSet GetAllUser()
        {
            using (AdminDAL adminDAL = new AdminDAL())
            {
                return adminDAL.GetAllUser();
            }
        }
        public void DeleteUser(int UserId)
        {
            using (AdminDAL adminDAL = new AdminDAL())
            {
                adminDAL.DeleteUser(UserId);
            }
        }
        public void AddUser(string Name, string Pass, string PName, string Email)
        {
            using (AdminDAL adminDAL = new AdminDAL())
            {
                adminDAL.AddUser(Name, Pass, PName, Email);
            }
        }
    }
}
