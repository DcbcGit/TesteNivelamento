using System;
using System.Globalization;

namespace Questao1
{
    class Program {
        static void Main(string[] args) {

            ContaBancaria conta1;
            ContaBancaria conta2;
            ServicoProcessamentoContasBancarias mvCnt = new ServicoProcessamentoContasBancarias();

            Console.WriteLine("* * * * * Inicio Exemplo 01 * * * * *");
            Console.WriteLine("Entre o número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre o titular da conta: ");
            string titular = Console.ReadLine();
            Console.WriteLine("Haverá depósito inicial (s/n)? ");
            char resp = char.Parse(Console.ReadLine());
            if (resp == 's' || resp == 'S')
            {
                Console.WriteLine("Entre o valor de depósito inicial: ");
                double depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta1 = mvCnt.AberturaConta(numero, titular, depositoInicial);
            }
            else
            {
                conta1 = mvCnt.AberturaConta(numero, titular);
            }

            if(conta1 == null)
            {
                Console.WriteLine("* * * * Erro(s) na abertura da conta: ");
                foreach (string err in mvCnt.Erros())
                    Console.WriteLine(err);
                Console.WriteLine();
                Environment.Exit(1);
            }

            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine(conta1);

            Console.WriteLine();
            Console.Write("Entre um valor para depósito: ");
            double quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            mvCnt.Deposito(conta1, quantia);
            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine(conta1);

            Console.WriteLine();
            Console.Write("Entre um valor para saque: ");
            quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            mvCnt.Saque(conta1, quantia);
            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine(conta1);

            Console.WriteLine();
            foreach (string ope in conta1.ObtemHistoricoOperacoes())
                Console.WriteLine(ope);
            Console.WriteLine();

            Console.WriteLine("* * * * * Final Exemplo 01 * * * * *" + Environment.NewLine);

            Console.WriteLine(Environment.NewLine + "* * * * * Inicio Exemplo 02 * * * * *");
            Console.WriteLine("Entre o número da conta: ");
            numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre o titular da conta: ");
            titular = Console.ReadLine();
            Console.WriteLine("Haverá depósito inicial (s/n)? ");
            resp = char.Parse(Console.ReadLine());
            if (resp == 's' || resp == 'S')
            {
                Console.WriteLine("Entre o valor de depósito inicial: ");
                double depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta2 = mvCnt.AberturaConta(numero, titular, depositoInicial);
            }
            else
            {
                conta2 = mvCnt.AberturaConta(numero, titular);
            }

            if (conta2 == null)
            {
                Console.WriteLine("* * * * Erro(s) na abertura da conta: ");
                foreach (string err in mvCnt.Erros())
                    Console.WriteLine(err);
                Console.WriteLine();
                Environment.Exit(1);
            }

            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine(conta2);

            Console.WriteLine();
            Console.Write("Entre um valor para depósito: ");
            quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            mvCnt.Deposito(conta2, quantia);
            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine(conta2);

            Console.WriteLine();
            Console.Write("Entre um valor para saque: ");
            quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            mvCnt.Saque(conta2, quantia);
            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine(conta2);

            Console.WriteLine();
            foreach (string ope in conta2.ObtemHistoricoOperacoes())
                Console.WriteLine(ope);
            Console.WriteLine();

            Console.WriteLine("* * * * * Final Exemplo 02 * * * * *");

            /* Output expected:
            Exemplo 1:

            Entre o número da conta: 5447
            Entre o titular da conta: Milton Gonçalves
            Haverá depósito inicial(s / n) ? s
            Entre o valor de depósito inicial: 350.00

            Dados da conta:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 350.00

            Entre um valor para depósito: 200
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 550.00

            Entre um valor para saque: 199
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 347.50

            Exemplo 2:
            Entre o número da conta: 5139
            Entre o titular da conta: Elza Soares
            Haverá depósito inicial(s / n) ? n

            Dados da conta:
            Conta 5139, Titular: Elza Soares, Saldo: $ 0.00

            Entre um valor para depósito: 300.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ 300.00

            Entre um valor para saque: 298.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ -1.50
            */
        }
    }
}
