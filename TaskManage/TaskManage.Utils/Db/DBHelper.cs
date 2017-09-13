using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Reflection;

namespace TaskManage.Utils.Db
{
    public class DBHelper
    {
        #region Properties

        private readonly DbProviderFactory _factory;
        private readonly string _connectionString;

        public DbProviderFactory Factory
        {
            get
            {
                return _factory;
            }
        }

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        #endregion

        #region Constructors

        public DBHelper(DbProviderFactory providerFactory, string connectionString)
        {
            if (providerFactory == null)
                throw new ArgumentNullException("providerFactory", "You must provide a DbProviderFactory instance.");

            if (String.IsNullOrEmpty(connectionString))
                throw new ArgumentException("The connection string cannot be empty.", "connectionString");

            _factory = providerFactory;
            _connectionString = connectionString;
        }

        public DBHelper(string connectionStringName)
        {
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (css == null)
                throw new ArgumentException("The connection string you specified does not exist in your configuration file.");

            _factory = DbProviderFactories.GetFactory(css.ProviderName);
            _connectionString = css.ConnectionString;
        }

        #endregion

        #region Private Helpers

        private string GetProviderParameterFormatString()
        {
            var builder = Factory.CreateCommandBuilder();
            var type = builder.GetType();
            var method = type.GetMethod("GetParameterPlaceholder", BindingFlags.NonPublic | BindingFlags.Instance);
            var index = 42;
            var parameterName = method.Invoke(builder, new object[] { index }).ToString();
            return parameterName.Replace(index.ToString(CultureInfo.InvariantCulture), "{0}");
        }
        protected virtual void OnExecuteCommand(DbCommand command)
        { }
        public DbConnection CreateConnection()
        {
            DbConnection connection = Factory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            return connection;
        }
        public DbCommand CreateCommand(string commandText, bool iSStoredProcedure = false, params object[] parameters)
        {
            var len = parameters.Length;
            var command = Factory.CreateCommand();
            command.CommandType = CommandType.Text;
            if (iSStoredProcedure)
            {
                command.CommandType = CommandType.StoredProcedure;
            }
            if (len > 0)
            {
                object[] formatValues = new object[len];

                for (var i = 0; i < len; i++)
                {
                    var parameter = parameters[i];
                    var rawValue = parameter as RawValue;

                    if (rawValue != null)
                    {
                        formatValues[i] = rawValue.Value;
                    }
                    else
                    {
                        var dbParameter = Factory.CreateParameter();
                        var name = CreateParameterName(i);

                        dbParameter.ParameterName = name;
                        dbParameter.Value = parameter ?? DBNull.Value;

                        formatValues[i] = name;
                        command.Parameters.Add(dbParameter);
                    }
                }

                command.CommandText = string.Format(commandText, formatValues);
            }
            else
            {
                command.CommandText = commandText;
            }

            return command;
        }

        private string _parameterFormat;

        protected virtual string CreateParameterName(int index)
        {
            if (_parameterFormat == null)
                _parameterFormat = GetProviderParameterFormatString();

            return String.Format(_parameterFormat, index);
        }
        #endregion

        #region ExecuteNonQuery
        public int ExecuteNonQuery(DbCommand command, DbConnection connection)
        {
            OnExecuteCommand(command);
            command.Connection = connection;
            return command.ExecuteNonQuery();
        }

        public int ExecuteNonQuery(DbCommand command, DbTransaction transaction)
        {
            OnExecuteCommand(command);
            command.Connection = transaction.Connection;
            command.Transaction = transaction;
            return command.ExecuteNonQuery();
        }

        public int ExecuteNonQuery(DbCommand command)
        {
            int affectedRows;
            using (DbConnection connection = CreateConnection())
            {
                connection.Open();
                affectedRows = ExecuteNonQuery(command, connection);
                connection.Close();
            }
            return affectedRows;
        }
        #endregion

        #region ExecuteReader

        public DbDataReader ExecuteReader(DbCommand command, DbConnection connection)
        {
            OnExecuteCommand(command);
            command.Connection = connection;
            return command.ExecuteReader();
        }

        public DbDataReader ExecuteReader(DbCommand command, DbTransaction transaction)
        {
            OnExecuteCommand(command);
            command.Connection = transaction.Connection;
            command.Transaction = transaction;
            return command.ExecuteReader();
        }

        public DbDataReader ExecuteReader(DbCommand command)
        {
            OnExecuteCommand(command);
            DbConnection connection = CreateConnection();
            command.Connection = connection;
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        #endregion

        #region ExecuteDataTable

        public DataTable ExecuteDataTable(DbCommand command, int startRecord, int maxRecords, DbConnection connection)
        {
            OnExecuteCommand(command);
            command.Connection = connection;
            DbDataAdapter adapter = Factory.CreateDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            if (startRecord > 0 || maxRecords > 0)
                adapter.Fill(startRecord, maxRecords, dt);
            else
                adapter.Fill(dt);
            return dt;
        }

        public DataTable ExecuteDataTable(DbCommand command, int startRecord, int maxRecords, DbTransaction transaction)
        {
            OnExecuteCommand(command);
            command.Connection = transaction.Connection;
            command.Transaction = transaction;
            DbDataAdapter adapter = Factory.CreateDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            if (startRecord >= 0 || maxRecords >= 0)
                adapter.Fill(startRecord, maxRecords, dt);
            else
                adapter.Fill(dt);
            return dt;

        }

        public DataTable ExecuteDataTable(DbCommand command, int startRecord = 0, int maxRecords = 0)
        {
            DataTable dt;

            using (DbConnection connection = CreateConnection())
            {
                connection.Open();

                dt = ExecuteDataTable(command, startRecord, maxRecords, connection);

                connection.Close();
            }

            return dt;
        }

        public DataTable ExecuteDataTable(DbCommand command, DbConnection connection)
        {
            return ExecuteDataTable(command, 0, 0, connection);
        }

        public DataTable ExecuteDataTable(DbCommand command, DbTransaction transaction)
        {
            return ExecuteDataTable(command, 0, 0, transaction);
        }

        #endregion

        #region ExecuteDataSet

        public DataSet ExecuteDataSet(DbCommand command, DbConnection connection)
        {
            OnExecuteCommand(command);
            command.Connection = connection;
            DbDataAdapter adapter = Factory.CreateDataAdapter();
            adapter.SelectCommand = command;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }

        public DataSet ExecuteDataSet(DbCommand command, DbTransaction transaction)
        {
            OnExecuteCommand(command);

            command.Connection = transaction.Connection;
            command.Transaction = transaction;

            DbDataAdapter adapter = Factory.CreateDataAdapter();
            adapter.SelectCommand = command;

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            return ds;
        }

        public DataSet ExecuteDataSet(DbCommand command)
        {
            DataSet ds;

            using (DbConnection connection = CreateConnection())
            {
                connection.Open();

                ds = ExecuteDataSet(command, connection);

                connection.Close();
            }

            return ds;
        }

        #endregion

    }
}
