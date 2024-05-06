using Newtonsoft.Json;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Common.Responses;
using Questao5.Application.Queries.Requests;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Interfaces;

namespace Questao5.Infrastructure.Services.Validation
{
 
    /// <summary>
    /// Classe Responsável pelas validadoes da conta e movimentação
    /// </summary>
    public class EmpotentialValidationService : IEmpotentialValidationService
    {

        private readonly IEmpotentialRepository _empoRepository;
        private readonly IAccountRepository _repository;
        public EmpotentialValidationService(IAccountRepository repository, IEmpotentialRepository empoRepository)
        {
            _empoRepository = empoRepository;
            _repository = repository;
        }

        public async Task<ResultService<CurrentAccountDomain>> ValidateAccountBalanceMovement(GetAccountBase request)
        {
            CurrentAccountDomain account = await GetAccount(request.NumberAccount);
            return await ValidateAccount(request, account);
        }

        public async Task<ResultService<CurrentAccountDomain>> ValidateDataMovement(InsertAccountMovementRequest request)
        {
            CurrentAccountDomain account = await GetAccount(request.NumberAccount);
            ResultService<CurrentAccountDomain> result = await ValidateAccount(request, account);

            if (result.IsSucess)
            {
                if (request.Value <= 0)
                {
                    return RegistersDataBase(request, account, "Valor da movimentação não pode ser menor igual a zero.", "INVALID_VALUE").Result;
                }

                if (request.TypeMovement.Length != 1 ||
                   (!request.TypeMovement.Equals("D") && !request.TypeMovement.Equals("C")))
                {
                    return RegistersDataBase(request, account, "Operação só operacom os tipo 'D' e 'C', respectivamente Débito e Crédito.", "INVALID_TYPE").Result;
                }
            }

            return result;
        }

        private async Task<ResultService<CurrentAccountDomain>> RegistersDataBase(object request, CurrentAccountDomain account, string message, string typeError)
        {
            ResultService<CurrentAccountDomain> result = new ResultService<CurrentAccountDomain>().Fail<CurrentAccountDomain>(message, account, typeError);

            EmpotentialDomain empotential = new EmpotentialDomain();
            empotential.requisicao = JsonConvert.SerializeObject(request);
            empotential.resultado = JsonConvert.SerializeObject(result);

            await _empoRepository.InsertEmpotential(empotential);

            return result;
        }

        private async Task<CurrentAccountDomain> GetAccount(int numberAccount) => await _repository.GetAccountByNumber(numberAccount);

        private async Task<ResultService<CurrentAccountDomain>> ValidateAccount(object request, CurrentAccountDomain account)
        {
            if (account == null)
            {
                return RegistersDataBase(request, account, "Conta não identificada.", "INVALID_ACCOUNT").Result;
            }
            else
            {
                if (account.Ativo == TypeStatusAccount.Inativo)
                {
                    return RegistersDataBase(request, account, "Conta não está ativa para oeprações.", "INACTIVE_ACCOUNT").Result;
                }
            }

            return new ResultService<CurrentAccountDomain> { Data = account, IsSucess = true };
        }
    }
}