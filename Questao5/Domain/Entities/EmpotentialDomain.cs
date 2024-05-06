namespace Questao5.Domain.Entities
{

    /// <summary>
    /// Classe base das operações de validação da movimentação
    /// </summary>
    public class EmpotentialDomain
    {
        public string chave_idempotencia { get => Guid.NewGuid().ToString(); }
        public string requisicao { get; set; } = string.Empty;
        public string resultado { get; set; } = string.Empty;
    }
}
