using System.Linq;

namespace Questao1
{
    public class ServicoProcessamentoContasBancarias
    {
        private ValidacaoServicoProcesamentoContaBancaria _validacao = new ValidacaoServicoProcesamentoContaBancaria();
        private double _valorTaxa = 3.5;
        public ContaBancaria AberturaConta(int numero, string titular, double valorIinicial = 0)
        {
            if (_validacao.ValidacaoAberturaConta(numero, titular))
            {
                ContaBancaria newConta = new ContaBancaria(numero, titular);

                if (valorIinicial > 0)
                {
                    newConta.RealizaDeposito += DepositoInterno;
                    newConta.Deposito(valorIinicial);
                    newConta.RealizaDeposito -= DepositoInterno;
                }

                return newConta;
            }

            return default;
        }

        private bool DepositoInterno(double valor)
        {
            return valor > 0;
        }

        private bool SaqueInterno(double valor)
        {
            return valor - _valorTaxa > 0;
        }

        public bool Deposito(ContaBancaria conta, double valor)
        {
            conta.RealizaDeposito += DepositoInterno;
            bool ret = conta.Deposito(valor);
            conta.RealizaDeposito -= DepositoInterno;
            return ret;
        }

        public bool Saque(ContaBancaria conta, double valor)
        {
            conta.RealizaSaque += SaqueInterno;
            valor = valor + _valorTaxa;
            bool ret = conta.Saque(valor);
            conta.RealizaSaque -= SaqueInterno;
            return ret;
        }

        public string[] Erros()
        {
            return _validacao.errorMsg.ToArray();
        }
    }
}
