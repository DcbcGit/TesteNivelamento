using MediatR;
using Questao5.Application.Common.Responses;
using Questao5.Application.Queries.Requests;

namespace Questao5.Application.Commands.Requests
{
    /// <summary>
    /// Classe request com os dados para inserção de movimentação da conta 
    /// </summary>
    public class InsertAccountMovementRequest : GetAccountBase, IRequest<ResultService>
    {
        public string TypeMovement { get; set; }
        public decimal Value { get; set; }
    }
}
