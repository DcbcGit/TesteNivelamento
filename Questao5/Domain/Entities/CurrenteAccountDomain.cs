using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Entities
{
    /// <summary>
    /// Classe base conta corrente
    /// </summary>
    public class CurrentAccountDomain
    {
        public string IdContaCorrente { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; } = string.Empty;
        public TypeStatusAccount Ativo { get; set; }
    }
}
