namespace Questao5.Application.Common.Responses
{
    /// <summary>
    /// Classe base de com os doados sobre o resultado de cada operação
    /// </summary>
    public class ResultService
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public string TypeError { get; set; }

        public ResultService Fail(string message) => new ResultService { Message = message };
        public ResultService<T> Fail<T>(string message, T data) where T : class => new ResultService<T> { Message = message, Data = data };
        public ResultService<T> Fail<T>(string message, T data, string typeError) where T : class => new ResultService<T> { Message = message, Data = data, TypeError = typeError };
        public ResultService Ok(string message) => new ResultService { Message = message };
        public ResultService<T> Ok<T>(string message, T data) where T : class => new ResultService<T> { IsSucess = true, Message = message, Data = data };
    }
}