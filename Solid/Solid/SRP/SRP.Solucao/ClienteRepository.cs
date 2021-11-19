using System.Data;
using System.Data.SqlClient;

namespace Solid.SRP.SRP.Solucao
{
    class ClienteRepository
    {
        public void AdicionarCliente(Cliente cliente)
        {          
            using (var conn = new SqlConnection())
            {
                var comando = new SqlCommand();

                conn.ConnectionString = "connectionString";
                comando.Connection = conn;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO CLIENTE ([NOME],[EMAIL],[CPF], [DATACADASTRO] VALUES (@NOME, @EMAIL, @CPF,@DATACADASTRO)";

                comando.Parameters.AddWithValue(parameterName: "NOME", cliente.Nome);
                comando.Parameters.AddWithValue(parameterName: "EMAIL", cliente.Email);
                comando.Parameters.AddWithValue(parameterName: "CPF", cliente.CPF);
                comando.Parameters.AddWithValue(parameterName: "DATACADASTRO", cliente.DataCadastro);

                conn.Open();
                comando.ExecuteNonQuery();

            }
        }
}
