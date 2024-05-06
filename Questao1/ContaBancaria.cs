using System.Collections.Generic;

namespace Questao1
{
    public class ContaBancaria
    {
        private int _numero;
        private string _titular;
        private double _valorSaldoConta = 0;
        private List<OperacoesBancarias> _lstOperacoes;

        public delegate bool HandleMovimento(double valor);
        public event HandleMovimento RealizaDeposito;
        public event HandleMovimento RealizaSaque;
        
        public ContaBancaria(int numero, string titular)
        {
            _numero = numero;
            _titular = titular;
            _lstOperacoes = new List<OperacoesBancarias>();
        }

        public int Numero { get => _numero; }
        public string Titular { get => _titular; set => _titular = value; }

        public double ObterSaldoConta() => _valorSaldoConta;

        public bool Deposito(double valor)
        {
            if (RealizaDeposito != null)
            {
                if (RealizaDeposito(valor))
                {
                    _valorSaldoConta += valor;
                    _lstOperacoes.Add(new OperacoesBancarias(TipoOperacao.Deposito, _valorSaldoConta, valor));
                }
                return true;
            }

            return false;
        }
        public bool Saque(double valor)
        {
            if (RealizaSaque != null)
            {
                if (RealizaSaque(valor))
                {
                    _valorSaldoConta -= valor;
                    _lstOperacoes.Add(new OperacoesBancarias(TipoOperacao.Saque, _valorSaldoConta, valor));
                    return true;
                }
            }

            return false;
        }

        public string[] ObtemHistoricoOperacoes()
        {
            string cabHist = $"Histórico Operações Conta:{Numero}, Titular:{Titular}";
            string rodHist = $"Saldo: {_valorSaldoConta:C2}";
            List<string> lstRet = new List<string>();
            lstRet.Add(cabHist);
            _lstOperacoes.ForEach(x => lstRet.Add(x.ToString()));
            lstRet.Add(rodHist);
            return lstRet.ToArray();
        }

        public override string ToString()
        {
            return $"Conta: {Numero}, Titular: {Titular}, Saldo: {_valorSaldoConta:C2} ";
        }
    }
}