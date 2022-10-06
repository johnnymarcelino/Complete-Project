using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMBank {
    internal class Cliente {
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Saldo { get; private set; }
        public List<Movimentacao> Movimentacoes { get; set; }

        public Cliente() {
            Movimentacoes = new List<Movimentacao>();
        }

        public Cliente(string codigo, string nome) : this() {
            Codigo = codigo;
            Nome = nome;
        }
        public void RealizarSaque(decimal valor) {
            if (Saldo > valor) {
                decimal valorMenosTaxa = DescontarTaxa(valor);
                Saldo = Saldo - valor;
                AdicionarMovimentacao("SAQUE", valorMenosTaxa);
                Console.WriteLine($"Saldo realizado com sucesso. Saldo: {Saldo}");
            }
            else
                Console.WriteLine("Valor insuficiente");
        }

        public void RealizarDeposito(decimal valor) {
            if (valor >= 0) {
                decimal valorMenosTaxa = DescontarTaxa(valor);
                Saldo += valorMenosTaxa;
                AdicionarMovimentacao("DEPÓSITO", valorMenosTaxa);
                Console.WriteLine($"Saldo realizado com sucesso. Saldo: {Saldo}");
            }
            else
                Console.WriteLine("Valor deve ser maior ou igual a R$ 10,00");
        }

        private void AdicionarMovimentacao(string tipo, decimal valor) {
            Movimentacoes.Add(new Movimentacao(tipo, DescontarTaxa(valor)));
        }

        public virtual decimal DescontarTaxa(decimal valor) { 
            return valor;
        }
    }
}
