using Dapper;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Repository
{
    /// <summary>
    /// Repositório responsavel pela gravação dos erros ocorridos na tentativa de inserir movimetação das contas.
    /// </summary>
    public class EmpotentialRepository : RepositoryBase, IEmpotentialRepository
    {
        public EmpotentialRepository(DatabaseConfig dbConfig) : base(dbConfig)
        {
        }

        public async Task<bool> InsertEmpotential(EmpotentialDomain empotential)
        {
            string cmdSql = @"INSERT INTO idempotencia
                              (chave_idempotencia, requisicao, resultado)
                              VALUES(@chave_idempotencia, @requisicao, @resultado);";

            var result = await _dbConnection.ExecuteAsync(sql: cmdSql, param: empotential);

            return true;
        }
    }
}