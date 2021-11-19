namespace Solid.SRP.SRP.Solucao
{
    public class CPF
    {
        public string Numero { get; set; }

        public bool Validar() => Numero.Length == 1;
    }
}
