namespace Questao5.Application.Common.Responses
{
    /// <summary>
    /// Classe base de retorno dos dados da operação
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}