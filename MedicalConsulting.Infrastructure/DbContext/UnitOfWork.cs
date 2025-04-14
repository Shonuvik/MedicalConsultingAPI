using System.Data;
using Microsoft.Data.SqlClient;

namespace MedicalConsulting.Infrastructure.DbContext
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public IDbConnection Connection
        {
            get
            {
                _connection = new SqlConnection("Server=localhost,1433;Database=master;User Id=sa;Password=MinhaSenha123;Encrypt=True;TrustServerCertificate=True;");
                _connection.Open();
                return _connection;
            }
        }

        public IDbTransaction Transaction => _transaction;

        public void Begin()
        {
            _transaction = _connection?.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
            _transaction?.Dispose();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}

