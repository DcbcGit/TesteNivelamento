using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IEmpotentialRepository
    {
        Task<bool> InsertEmpotential(EmpotentialDomain empotential);
    }
}
