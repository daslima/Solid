using System;

namespace Solid.SRP.SRP.Solucao
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Email Email { get; set; }
        public CPF CPF { get; set; }
        public DateTime DataCadastro { get; set; }

        public bool Validar() => Email.Validar() && CPF.Validar();
       
    }
}
