using Rental_Manha.Domains;
using Rental_Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Manha.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        //String de Conexão do Senai
        private string stringConexao = @"Data Source=NOTE0113A4\SQLEXPRESS; initial catalog=Rental_Manha; user id=sa; pwd=Senai@132";

        //String de Conexão de Casa
        //private string stringConexao = @"Data Source=DESKTOP-NI590A9\SQLEXPRESS; initial catalog=Rental_Manha; user Id=sa; pwd=thiaguinho33";
        public void AtualizarIdCorpo(ClienteDomain ClienteAtualizado)
        {
            if (ClienteAtualizado.nomeCliente != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE cliente SET nomeCliente = @novoNomeCliente, cpfCliente = @novoCpfCliente WHERE idCliente = @idClienteAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@NovoNomeCliente", ClienteAtualizado.nomeCliente);
                        cmd.Parameters.AddWithValue("@novoCpfCliente", ClienteAtualizado.cpfCliente);
                        cmd.Parameters.AddWithValue("@idClienteAtualizado", ClienteAtualizado.idCliente);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtualizarIdUrl(int idCliente, ClienteDomain ClienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE cliente SET nomeCliente = @novoNomeCliente, cpfCliente = @novoCpfCliente WHERE idCliente = @idClienteAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeCliente", ClienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@novoCpfCliente", ClienteAtualizado.cpfCliente);
                    cmd.Parameters.AddWithValue("@idClienteAtualizado", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idCliente, nomeCliente, cpfCliente FROM cliente WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(reader["idCliente"]),
                            nomeCliente = reader["nomeCliente"].ToString(),
                            cpfCliente = Convert.ToInt64(reader["cpfCliente"])
                        };
                        return clienteBuscado;
                    }
                    return null;
                }
            };
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO cliente (nomeCliente, cpfCliente) VALUES (@nomeCliente, @cpfCliente)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@cpfCliente", novoCliente.cpfCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM cliente WHERE idCliente = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> ListaClientes = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idCliente, nomeCliente, cpfCliente FROM cliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain Cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),
                            nomeCliente = rdr[1].ToString(),
                            cpfCliente = Convert.ToInt64(rdr[2])
                        };
                        ListaClientes.Add(Cliente);
                    }
                }
            }
            return ListaClientes;
        }
    }
}