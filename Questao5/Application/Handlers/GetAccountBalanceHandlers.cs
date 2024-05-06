using MediatR;
using Questao5.Application.Common.Responses;
using Questao5.Application.Queries.Requests;
using Questao5.Domain.Dto;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;

namespace Questao5.Application.Handlers
{
    /// <summary>
    /// Classe Handle responsável por obeter o saldo através do número da conta
    /// </summary>
    public class GetAccountBalanceHandlers : IRequestHandler<GetAccountBalanceRequest, ResultService>
    {
        private readonly IAccountRepository _repository;
        private readonly IEmpotentialValidationService _validation;

        public GetAccountBalanceHandlers(IAccountRepository repository, IEmpotentialValidationService validation)
        {
            _repository = repository;
            _validation = validation;
        }

        public async Task<ResultService> Handle(GetAccountBalanceRequest request, CancellationToken cancellationToken)
        {
            try
            {
                ResultService<CurrentAccountDomain> account = await _validation.ValidateAccountBalanceMovement(request);
                if (!account.IsSucess)
                    return account;

                CurrenteAccountHasMovement accountMov = await _repository.GetAccountBalance(request.NumberAccount);

                AccountBalanceDto acoBal = new AccountBalanceDto
                {
                    AccountNumber = accountMov.Numero,
                    Holder = accountMov.Nome,
                    BalenceValue = accountMov.AccountBalance()
                };

                return new ResultService<AccountBalanceDto>().Ok<AccountBalanceDto>("success", acoBal);
            }
            catch (Exception err)
            {
                return new ResultService<AccountBalanceDto>().Fail<AccountBalanceDto>($"Falha ao consultar contas ero:{err.Message}", null);
            }
        }
    }
}