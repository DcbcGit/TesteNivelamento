using Dapper;
using Questao5.Domain.Dto;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Repository
{
    /// <summary>
    /// Repositoório responsavel pela operações com contas.
    /// </summary>
    public class AccountRepository : RepositoryBase, IAccountRepository
    {
        public AccountRepository(DatabaseConfig dbConfig) : base(dbConfig)
        {
        }

        /// <summary>
        /// Método para busca a conta pelo número
        /// </summary>
        /// <param name="number">int</param>
        /// <returns>Task<CurrentAccountDomain></returns>
        public async Task<CurrentAccountDomain> GetAccountByNumber(int number)
        {
            string cmdSql = "SELECT * FROM contacorrente WHERE numero = @number";

            CurrentAccountDomain account = await _dbConnection.QueryFirstOrDefaultAsync<CurrentAccountDomain>(cmdSql, param: new { number });

            return account;
        }

        /// <summary>
        /// Método para retorna todas as contas utilizando paginação
        /// </summary>
        /// <param name="page">int</param>
        /// <param name="pageSize">int</param>
        /// <returns>Task<CurrentAccountListResultDto></returns>
        public async Task<CurrentAccountListResultDto> GetAllAccount(int page = 0, int pageSize = 10)
        {
            string cmdSql = $@" SELECT COUNT(*) FROM contacorrente;
                                SELECT * FROM contacorrente LIMIT @pageSize OFFSET @page ";

            var result = await _dbConnection.QueryMultipleAsync(sql: cmdSql, param: new { pageSize, page });

            CurrentAccountListResultDto retData = new CurrentAccountListResultDto();
            retData.TotalAmountRecords = (await result.ReadAsync<Int64>()).FirstOrDefault();
            retData.Accounts = (await result.ReadAsync<CurrentAccountDomain>()).ToList();

            return retData;
        }

        /// <summary>
        /// Método para inservir movimetação das contas
        /// </summary>
        /// <param name="movement">AccountMovementDomain</param>
        /// <returns>Task<bool></returns>
        public async Task<bool> InsertAccountMovement(AccountMovementDomain movement)
        {
            string cmdSql = @"INSERT INTO movimento
                              (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor)
                              VALUES(@idmovimento, @idcontacorrente, @datamovimento, @tipomovimento , @valor);";

            var result = await _dbConnection.ExecuteAsync(sql: cmdSql, param: new
            {
                idmovimento = movement.IdMovimento,
                idcontacorrente = movement.IdContaCorrente,
                datamovimento = movement.DataMovimento.Date.ToString(),
                tipomovimento = (char)movement.TipoMovimento,
                valor = movement.Valor
            });

            return result == 1;
        }

        /// <summary>
        /// Método para buscar a conta com suas movimentações, pelo número da conta
        /// </summary>
        /// <param name="numberAccount"></param>
        /// <returns>Task<CurrenteAccountHasMovement></returns>
        public async Task<CurrenteAccountHasMovement> GetAccountBalance(int numberAccount)
        {
            string cmdSql = $@"SELECT c.idcontacorrente, c.numero, c.nome, c.ativo,
                                     mov.idmovimento, mov.idcontacorrente, mov.datamovimento, mov.tipomovimento, mov.valor       
                                FROM contacorrente c LEFT JOIN  movimento mov ON c.idcontacorrente  = mov.idcontacorrente 
                               WHERE c.numero = @numberAccount";

            Dictionary<string, CurrenteAccountHasMovement> accounts = new Dictionary<string, CurrenteAccountHasMovement>();

            var result = _dbConnection.QueryAsync<CurrenteAccountHasMovement, AccountMovementDomain, CurrenteAccountHasMovement>(
                cmdSql,
                (account, movement) =>
                {
                    if (!accounts.TryGetValue(account.IdContaCorrente, out var accountFound))
                    {
                        accountFound = account;
                        accountFound.Movements = new List<AccountMovementDomain>();
                        accounts.Add(accountFound.IdContaCorrente, accountFound);
                    }
                    accountFound.Movements.Add(movement);
                    return accountFound;
                }
                , param: new { numberAccount }
                , splitOn: "idmovimento"
                );

            return result.Result.First();
        }
    }
}