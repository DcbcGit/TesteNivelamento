namespace Questao5.Domain.Dto
{
    /// <summary>
    /// Classe transferência de retorno para o saldo da conta
    /// </summary>
    public class AccountBalanceDto
    {
        public int AccountNumber { get; set; }
        public string Holder { get; set; }
        public string DateTimeResult { get => DateTime.Now.Date.ToString(); }
        public decimal BalenceValue { get; set; }
    }
}
