using System.Data;

namespace MedicalConsulting.Infrastructure.DbContext
{
    public interface IUnitOfWork : IDisposable
	{
		public IDbConnection Connection { get; }

		public IDbTransaction Transaction { get; }
	}
}
