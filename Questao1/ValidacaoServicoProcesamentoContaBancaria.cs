using System.Collections.Generic;

namespace Questao1
{
    public sealed class ValidacaoServicoProcesamentoContaBancaria : IValidacaoContaBancaria
    {
        private List<string> _erros;

        public IList<string> errorMsg => _erros;

        public bool ValidacaoAberturaConta(int numero, string titular)
        {
            _erros = new List<string>();

            if (numero <= 0)
            {
                _erros.Add("Conta não informada.");
            }

            if (string.IsNullOrEmpty(titular))
            {
                _erros.Add("Nome do titular da conta não foi informado.");
            }

            return _erros.Count <= 0;
        }
    }
}