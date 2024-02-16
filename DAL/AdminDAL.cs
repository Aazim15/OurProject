using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminDAL : DBHelper
    {
        public DataSet GetAllUser()
        {
            return ExecDataSetProc("GetAllUser");
        }
        public void DeleteUser(int UserId)
        {
            List<SqlParameter> Sqlcomm = new List<SqlParameter>();
            Sqlcomm.Add(AddParameter("@userid", SqlDbType.Int, UserId));
            ExecDataSetProc("DeleteUser", Sqlcomm.ToArray());
        }
        public void AddUser(string Name, string Pass, string PName, string Email)
        {
            List<SqlParameter> Sqlcomm = new List<SqlParameter>();
            Sqlcomm.Add(AddParameter("@ParkingName", SqlDbType.NChar, PName));
            Sqlcomm.Add(AddParameter("@Name", SqlDbType.NChar, Name));
            Sqlcomm.Add(AddParameter("@Email", SqlDbType.NChar, Email));
            Sqlcomm.Add(AddParameter("@Password", SqlDbType.NChar, Pass));
            ExecDataSetProc("CreateUser", Sqlcomm.ToArray());
        }
    }
}
