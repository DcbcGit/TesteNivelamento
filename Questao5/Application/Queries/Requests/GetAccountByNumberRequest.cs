using MediatR;
using Questao5.Application.Common.Responses;
using Questao5.Domain.Entities;

namespace Questao5.Application.Queries.Requests
{
    /// <summary>
    /// Classe Request com o número da conta a ser pesquisada
    /// </summary>
    public class GetAccountByNumberAccountRequest : GetAccountBase,  IRequest<ResultService<CurrentAccountDomain>>
    {
    }
}