using Questao5.Domain.Entities;

namespace Questao5.Domain.Dto
{
    /// <summary>
    /// Classe transferência da listagem de contas corrente para paginação
    /// </summary>
    public class CurrentAccountListResultDto
    {
        public Int64 TotalAmountRecords { get; set; }
        public List<CurrentAccountDomain> Accounts { get; set; } = new List<CurrentAccountDomain>();
    }
}
