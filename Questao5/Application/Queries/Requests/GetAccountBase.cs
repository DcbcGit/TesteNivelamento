namespace Questao5.Application.Queries.Requests
{
    /// <summary>
    /// Clase Base para todas que queiram utilizar o número da conta para pesquisar
    /// </summary>
    public class GetAccountBase
    {
        public int NumberAccount { get; set; }
    }
}