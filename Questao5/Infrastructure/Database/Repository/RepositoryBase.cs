using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Repository
{
    public abstract class RepositoryBase: IDisposable
    {
        protected readonly DatabaseConfig _dbConfig;
        protected SqliteConnection _dbConnection;

        public RepositoryBase(DatabaseConfig dbConfig)
        {
            _dbConfig = dbConfig;
            _dbConnection = new SqliteConnection(_dbConfig.Name);
        }

        public void Dispose() => _dbConnection.Dispose();
    }
}
