using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace Solid.SRP.SRP.Violacao
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataCadastro { get; set; }

   
        public string AdicionarCliente()
        {
            //Validando
            if (!Email.Contains(value: "@"))
                return "Cliente com e-mail inválido.";

            if (CPF.Length != 11)
                return "Cliente com CPF inválido";

            //Conexão com o banco
            using(var conn = new SqlConnection())
            {
                var comando = new SqlCommand();

                conn.ConnectionString = "connectionString";
                comando.Connection = conn;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO CLIENTE ([NOME],[EMAIL],[CPF], [DATACADASTRO] VALUES (@NOME, @EMAIL, @CPF,@DATACADASTRO)";

                comando.Parameters.AddWithValue(parameterName: "NOME", Nome);
                comando.Parameters.AddWithValue(parameterName: "EMAIL", Email);
                comando.Parameters.AddWithValue(parameterName: "CPF", CPF);
                comando.Parameters.AddWithValue(parameterName: "DATACADASTRO", DataCadastro);

                conn.Open();
                comando.ExecuteNonQuery();

            }

            //Enviando Email
            var mail = new MailMessage("email@email.com", Email);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };


            mail.Subject = "Bem Vindo.";
            mail.Body = "Parabéns ! Você está Cadastrado.";
            client.Send(mail);

            return "Cliente Cadastrado com sucesso!";

        }
    }
}
