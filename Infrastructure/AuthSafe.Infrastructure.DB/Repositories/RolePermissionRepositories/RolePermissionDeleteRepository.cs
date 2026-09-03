using AuthSafe.Infrastructure.DB.AppDBContext;
using AuthSafe.Infrastructure.DB.Transactions;
using AuthSafe.DomainService.IRepositories.IRolePermissionRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.RolePermissionRepositories
{
    internal class RolePermissionDeleteRepository : IRolePermissionDeleteRepository
    {
        private readonly string ConnectionString;
        private readonly ITransactionAccessor TransactionAccessor;
        public RolePermissionDeleteRepository(IOptions<AppDbContext> Options, ITransactionAccessor TransactionAccessor)
        {
            ConnectionString = Options.Value.ConnectionSQLServer;
            this.TransactionAccessor = TransactionAccessor;
        }
        public async Task<int> DeleteAsync(int RoleID, CancellationToken CancellationToken = default)
        {
            int RecordAffected = 0;
            var Connection = await TransactionAccessor.GetOrOpenConnectionAsync(ConnectionString, CancellationToken);
            var Transaction = TransactionAccessor.CurrentTransaction;
            using (SqlCommand Command = new SqlCommand())
            {
                Command.CommandText = "Security.uspRolePermissionDelete";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@RoleID", RoleID);
                Command.Connection = Connection;
                Command.Transaction = Transaction;
                RecordAffected = await Command.ExecuteNonQueryAsync(CancellationToken);
            }
            return RecordAffected;
        }
    }
}
