using System.Collections.Generic;

namespace Questao1
{
    public interface IValidacaoContaBancaria
    {
        bool ValidacaoAberturaConta(int numero, string titular);
        IList<string> errorMsg { get; }
    }
}