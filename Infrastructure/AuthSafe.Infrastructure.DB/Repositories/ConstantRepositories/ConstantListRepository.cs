using AuthSafe.Infrastructure.DB.AppDBContext;
using AuthSafe.Infrastructure.DB.Extensions;
using AuthSafe.Infrastructure.DB.Transactions;
using AuthSafe.DomainModel.Dtos.Constant;
using AuthSafe.DomainService.IRepositories.IConstantRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.ConstantRepositories
{
    internal class ConstantListRepository : IConstantListRepository
    {
        private readonly string ConnectionString;
        private readonly ITransactionAccessor TransactionAccessor;
        public ConstantListRepository(IOptions<AppDbContext> Options, ITransactionAccessor TransactionAccessor)
        {
            ConnectionString = Options.Value.ConnectionSQLServer;
            this.TransactionAccessor = TransactionAccessor;
        }

        public async Task<List<ConstantListResponseDto>> ListAsync(string ConstantClass, CancellationToken CancellationToken = default)
        {
            var List = new List<ConstantListResponseDto>();
            var Connection = await TransactionAccessor.GetOrOpenConnectionAsync(ConnectionString, CancellationToken);
            using (SqlCommand Command = new SqlCommand())
            {
                Command.CommandText = "Security.uspConstantList";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@ConstantClass", ConstantClass);
                Command.Connection = Connection;
                SqlDataReader DataReader;
                using (DataReader = await Command.ExecuteReaderAsync(CancellationToken))
                {
                    if (DataReader.HasRows)
                    {
                        while (await DataReader.ReadAsync(CancellationToken))
                        {
                            var Get = new ConstantListResponseDto()
                            {
                                ConstantID = Validation.SqlDBToInt16(ref DataReader, "ConstantID"),
                                ConstantClass = Validation.SqlDBToInt32(ref DataReader, "ConstantClass"),
                                ConstantAbbreviation = Validation.SqlDBToString(ref DataReader, "ConstantAbbreviation"),
                                ConstantName = Validation.SqlDBToString(ref DataReader, "ConstantName"),
                            };
                            List.Add(Get);
                        }
                    }
                }
            }
            return List;
        }
    }
}
