using Questao5.Application.Commands.Requests;
using Questao5.Application.Common.Responses;
using Questao5.Application.Queries.Requests;
using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IEmpotentialValidationService
    {
        Task<ResultService<CurrentAccountDomain>> ValidateDataMovement(InsertAccountMovementRequest request);
        Task<ResultService<CurrentAccountDomain>> ValidateAccountBalanceMovement(GetAccountBase request);
    }
}