using Questao5.Application.Common.Pagineted;
using Questao5.Domain.Entities;

namespace Questao5.Application.Queries.Requests
{
    /// <summary>
    /// Classe Request par obter todas as contas, com controle de paginação
    /// </summary>
    public class GetAllAccountRequest : AbstractPaginetedList<PaginatedList<CurrentAccountDomain>>
    {
    }
}