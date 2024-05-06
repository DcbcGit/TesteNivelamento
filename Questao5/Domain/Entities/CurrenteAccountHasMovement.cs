namespace Questao5.Domain.Entities
{
    /// <summary>
    /// Classe base conta corrente com sua movimentação
    /// </summary>
    public class CurrenteAccountHasMovement : CurrentAccountDomain
    {
        public List<AccountMovementDomain> Movements { get; set; } = new List<AccountMovementDomain>();

        public decimal AccountBalance()
        {
            decimal cre = Movements.Where(x => x.TipoMovimento == 'C').Sum(v => v.Valor);
            decimal deb = Movements.Where(x => x.TipoMovimento == 'D').Sum(v => v.Valor);

            return cre - deb;
        }
    }
}
