namespace Questao5.Application.Common.Pagineted
{
    /// <summary>
    /// Classe para toda oerapão de response, retornando os dados da paginação bem como os dados processados.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginatedList<T>
    {
        public PaginatedList(IList<T> items, int pageIndex, Int64 count, int pageSize)
        {
            PageIndex = pageIndex;
            TotalRegCount = count;
            Items = items;
            TotalPages = ((int)Math.Ceiling(count / (double)pageSize));
        }

        public int PageIndex { get; }
        public int TotalPages { get; }
        public Int64 TotalRegCount { get; }

        public IList<T> Items { get; }
    }
}