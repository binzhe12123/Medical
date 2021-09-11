using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Clinic.Repository
{
    public class IDbConnection : DbConnection
    {
        private DbConnectionInternal _innerConnection;        
        public IDbConnection(string connectionstring)
        {
            this.ConnectionString = connectionstring;
        }

        public override string ConnectionString { get; set; }

        public override string Database => "";

        public override string DataSource => "";

        public override string ServerVersion => throw new NotImplementedException();

        public override ConnectionState State => throw new NotImplementedException();
        public IDbConnection()
        {
            GC.SuppressFinalize(this);
            _innerConnection = DbConnectionClosedNeverOpened.SingletonInstance;
        }

        public override void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void Open()
        {
            throw new NotImplementedException();
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        protected override DbCommand CreateDbCommand()
        {
            throw new NotImplementedException();
        }
    }
}
