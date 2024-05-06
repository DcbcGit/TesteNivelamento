using MediatR;
using Questao5.Application.Common.Responses;
using Questao5.Application.Queries.Requests;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;

namespace Questao5.Application.Handlers
{
    /// <summary>
    /// Classe Handler de execução para obter uma conta usando o número da mesma
    /// </summary>
    public class GetAccountByNumberHandlers : IRequestHandler<GetAccountByNumberAccountRequest, ResultService<CurrentAccountDomain>>
    {
        private readonly IEmpotentialValidationService _validation;

        public GetAccountByNumberHandlers(IEmpotentialValidationService validation)
        {
            _validation = validation;
        }

        public async Task<ResultService<CurrentAccountDomain>> Handle(GetAccountByNumberAccountRequest request, CancellationToken cancellationToken)
        {
            try
            {
                ResultService<CurrentAccountDomain> account = await _validation.ValidateAccountBalanceMovement(request);

                if (!account.IsSucess)
                    return account;

                return new ResultService<CurrentAccountDomain>().Ok<CurrentAccountDomain>("success", account.Data);
            }
            catch (Exception err)
            {
                return new ResultService<CurrentAccountDomain>().Fail<CurrentAccountDomain>($"Falha ao consultar contas ero:{err.Message}", null);
            }
        }
    }
}