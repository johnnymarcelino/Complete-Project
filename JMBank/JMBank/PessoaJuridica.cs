using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMBank {
    internal class PessoaJuridica : Cliente {
        public PessoaJuridica(string codigo, string nome) : base(codigo, nome) {

        }

        public override decimal DescontarTaxa(decimal valor) {
            return valor - 2;
        }
    }
}
