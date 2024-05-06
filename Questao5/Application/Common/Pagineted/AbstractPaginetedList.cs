using MediatR;
using Questao5.Application.Common.Responses;

namespace Questao5.Application.Common.Pagineted
{
    /// <summary>
    /// Classe base de controle de paginação
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AbstractPaginetedList<T> : IRequest<ResultService<T>>
    {
        public int CurrentPage { get; set; }
        public int RegistrationQuantityPerPage { get; set; }

        public int GetOffSet()
        {
            if (CurrentPage >= 1)
                return CurrentPage * RegistrationQuantityPerPage;

            return 0;
        }

        public PaginatedList<T> ReturnPage(IList<T> item, int count) =>
            new PaginatedList<T>(item, count, CurrentPage, RegistrationQuantityPerPage);
    }
}