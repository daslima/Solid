namespace Solid.SRP.SRP.Solucao
{
    public class ClienteService
    {
        public string AdicionarCliente(Cliente cliente)
        {
            if (!cliente.Validar())
                return "Dados Inválidos";

            var repo = new ClienteRepository();
            repo.AdicionarCliente(cliente);

            EmailService.Enviar(de: "Empresa@outlook.com", para: cliente.Email.Endereco, assunto: "Bem Vindo", mensagem: "Parabéns ! Você está Cadastrado.");

            return "Cliente cadastrado com sucesso";
        }
    }
}
