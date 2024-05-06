using Questao5.Domain.Dto;
using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<CurrentAccountListResultDto> GetAllAccount(int page = 0, int pageSize = 10);
        Task<CurrentAccountDomain> GetAccountByNumber(int numbert);
        Task<bool> InsertAccountMovement(AccountMovementDomain movement);
        Task<CurrenteAccountHasMovement> GetAccountBalance(int numberAccount);
    }
}
