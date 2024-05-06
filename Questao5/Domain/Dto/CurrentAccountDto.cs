using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Dto
{
    /// <summary>
    /// Classe transferência da conta corrente.
    /// </summary>
    public class CurrentAccountDto
    {
        public string IdContaCorrente { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; }
        public TypeStatusAccount Ativo { get; set; }
    }
}
