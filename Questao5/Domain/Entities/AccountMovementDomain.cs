using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Entities
{
    /// <summary>
    /// Classe Base movimentação da conta
    /// </summary>
    public class AccountMovementDomain
    {
        public string IdMovimento { get => Guid.NewGuid().ToString(); }
        public string IdContaCorrente { get; set; }
        public DateTime DataMovimento { get; set; }
        public char TipoMovimento { get; set; }
        public decimal Valor { get; set; }
    }
}
