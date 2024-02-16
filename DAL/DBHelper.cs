using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class DBHelper : IDisposable
    {
        protected string _connString = null;
        protected SqlConnection _conn = null;
        protected SqlTransaction _trans = null;
        protected bool _disposed = false;

        public static string ConnectionString { get; set; }

        public SqlTransaction Transaction { get { return _trans; } }

        #region Connections
        public DBHelper()
        {

            _connString = ConfigurationManager.AppSettings["SQLCon"];
            Connect();
        }
        public DBHelper(SqlConnection sqlConnection, SqlTransaction transaction)
        {
            _conn = sqlConnection;
            _trans = transaction;
        }
        public DBHelper(string connString)
        {
            _connString = connString;
            Connect();
        }

        protected void Connect()
        {
            _conn = new SqlConnection(_connString);
            _conn.Open();
        }
        public SqlTransaction BeginTransaction()
        {
            Rollback();
            _trans = _conn.BeginTransaction();
            return Transaction;
        }
        public SqlConnection GetConnection()
        {
            return _conn;
        }
        public void Close()
        {
            if (_conn != null)
            {
                _conn.Close();
                _trans = null;
            }
        }
        public void Commit()
        {
            if (_trans != null)
            {
                _trans.Commit();
                _trans = null;
            }
        }

        public void Rollback(SqlTransaction transaction)
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }
        }
        public void Rollback()
        {
            if (_trans != null)
            {
                _trans.Rollback();
                _trans = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_conn != null)
                    {
                        Rollback();
                        _conn.Dispose();
                        _conn = null;
                    }
                }
                _disposed = true;
            }
        }
        #endregion
        public SqlCommand CreateCommand(string qry, CommandType type, params object[] args)
        {
            SqlCommand cmd = new SqlCommand(qry, _conn);
            if (_trans != null)
                cmd.Transaction = _trans;
            cmd.CommandType = type;
            cmd.CommandTimeout = 300;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] is string && i < (args.Length - 1))
                {
                    SqlParameter parm = new SqlParameter();
                    parm.ParameterName = (string)args[i];
                    parm.Value = args[++i];
                    cmd.Parameters.Add(parm);
                }
                else if (args[i] is SqlParameter)
                {
                    cmd.Parameters.Add((SqlParameter)args[i]);
                }
                else throw new ArgumentException("Invalid number or type of arguments supplied");
            }
            return cmd;
        }

        public int ExecNonQuery(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.Text, args))
            {
                return cmd.ExecuteNonQuery();
            }
        }
        public SqlCommand ExecNonQueryProc_GetSqlCommand(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.StoredProcedure, args))
            {
                cmd.ExecuteNonQuery();
                return cmd;
            }
        }

        public int ExecNonQueryProc(string proc, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(proc, CommandType.StoredProcedure, args))
            {
                return cmd.ExecuteNonQuery();
            }
        }
        public int ExecGetNextID(string tableName, string columnName)
        {
            List<SqlParameter> SQLPars = new List<SqlParameter>();
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@TableName", SqlDbType.Text);
            Sqlparam.Value = tableName;
            SQLPars.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ColumnName", SqlDbType.Text);
            Sqlparam.Value = columnName;
            SQLPars.Add(Sqlparam);
            return int.Parse(ExecScalarProc("Get_IDFromString", SQLPars.ToArray()).ToString());
        }
        public SqlParameterCollection ExecNonQueryProc_GetParams(string proc, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(proc, CommandType.StoredProcedure, args))
            {
                cmd.ExecuteNonQuery();
                return cmd.Parameters;
            }
        }
        public object ExecScalar(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.Text, args))
            {
                return cmd.ExecuteScalar();
            }
        }
        public SqlParameter AddParameter(string Name, SqlDbType Type, object Value)
        {
            SqlParameter sqlParameter = new SqlParameter(Name, Type);
            sqlParameter.Value = Value;
            return sqlParameter;
        }
        public SqlParameter AddParameter(string Name, SqlDbType Type, ParameterDirection direction, int size)
        {
            SqlParameter sqlParameter = new SqlParameter(Name, Type);
            sqlParameter.Direction = direction;
            sqlParameter.Size = size;
            return sqlParameter;
        }

        public object ExecScalarProc(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.StoredProcedure, args))
            {
                return cmd.ExecuteScalar();
            }
        }

        public SqlDataReader ExecDataReader(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.Text, args))
            {
                return cmd.ExecuteReader();
            }
        }

        public SqlDataReader ExecDataReaderProc(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.StoredProcedure, args))
            {
                return cmd.ExecuteReader();
            }
        }

        public DataSet ExecDataSet(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.Text, args))
            {
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                return ds;
            }
        }

        public DataSet ExecDataSetProc(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.StoredProcedure, args))
            {
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                return ds;
            }
        }
    }
}