using MediatR;
using Questao5.Application.Common.Pagineted;
using Questao5.Application.Common.Responses;
using Questao5.Application.Queries.Requests;
using Questao5.Domain.Dto;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;

namespace Questao5.Application.Handlers
{
    /// <summary>
    /// Classe Handlers para se obter todoas as contas de forma paginada
    /// </summary>
    public class GetAllAccountHandlers : IRequestHandler<GetAllAccountRequest, ResultService<PaginatedList<CurrentAccountDomain>>>
    {
        private readonly IAccountRepository _repository;

        public GetAllAccountHandlers(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultService<PaginatedList<CurrentAccountDomain>>> Handle(GetAllAccountRequest request, CancellationToken cancellationToken)
        {
            try
            {
                CurrentAccountListResultDto lstAccount = await _repository.GetAllAccount(request.GetOffSet(), request.RegistrationQuantityPerPage);

                return new ResultService().Ok("success", new PaginatedList<CurrentAccountDomain>(lstAccount.Accounts, request.CurrentPage, lstAccount.TotalAmountRecords, request.RegistrationQuantityPerPage));
            }
            catch (Exception err)
            {
                return new ResultService().Fail($"Falha ao consultar contas erro:{err.Message}", new PaginatedList<CurrentAccountDomain>(null, 0, 0, 0));
            }
        }
    }
}