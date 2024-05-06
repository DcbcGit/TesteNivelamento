using System;

namespace Questao1
{
    public class OperacoesBancarias
    {
        private double _saldoAposOperacao = 0;
        private double _valorOperacao = 0;
        private TipoOperacao _tpOperacao;
        private DateTime _dtOperacao = DateTime.Now;
        public OperacoesBancarias() { }

        public OperacoesBancarias(TipoOperacao operacao, double valorSaldoAtual, double valor)
        {
            _tpOperacao = operacao;
            _valorOperacao = valor;
            _saldoAposOperacao = valorSaldoAtual;
        }

        public override string ToString() 
        {
            return $" Data: {_dtOperacao.ToShortDateString()}, Operação: {_tpOperacao.ToString()}, Valor: {_valorOperacao:C2}, Saldo: {_saldoAposOperacao:C2}";
        }
    }
}