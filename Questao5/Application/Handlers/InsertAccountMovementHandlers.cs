using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Common.Responses;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;

namespace Questao5.Application.Handlers
{
    /// <summary>
    /// Classe Handlers responsável pela inserção da movimentação
    /// </summary>
    public class InsertAccountMovementHandlers : IRequestHandler<InsertAccountMovementRequest, ResultService>
    {
        private readonly IAccountRepository _repository;
        private readonly IEmpotentialValidationService _empoValidate;

        public InsertAccountMovementHandlers(IAccountRepository repository, IEmpotentialValidationService empoValidate)
        {
            _repository = repository;
            _empoValidate = empoValidate;
        }

        public async Task<ResultService> Handle(InsertAccountMovementRequest request, CancellationToken cancellationToken)
        {
            try
            {
                ResultService<CurrentAccountDomain> account = await _empoValidate.ValidateDataMovement(request);
                if (!account.IsSucess)
                    return account;

                AccountMovementDomain mov = new AccountMovementDomain
                {
                    IdContaCorrente = account.Data.IdContaCorrente,
                    DataMovimento = DateTime.Now,
                    TipoMovimento = request.TypeMovement[0],
                    Valor = request.Value
                };

                await _repository.InsertAccountMovement(mov);
                return new ResultService<string> { Data = mov.IdMovimento, IsSucess = true, Message = "Movimentação realizada com sucesso" };
            }
            catch (Exception err)
            {
                return new ResultService().Fail($"Falha ao inserir movimentação da conta número: {request.NumberAccount} erro:{err.Message}");
            }
        }
    }
}