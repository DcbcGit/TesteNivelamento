using MediatR;
using Questao5.Application.Common.Responses;

namespace Questao5.Application.Queries.Requests
{
    /// <summary>
    /// Classe Requesta para obter o saldo da conta passando o número da mesma
    /// </summary>
    public class GetAccountBalanceRequest: GetAccountBase, IRequest<ResultService>
    {
    }
}
