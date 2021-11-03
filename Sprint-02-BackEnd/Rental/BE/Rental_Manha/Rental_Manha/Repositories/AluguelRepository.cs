using Rental_Manha.Domains;
using Rental_Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Manha.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        //String de Conexão do Senai
        private string stringConexao = @"Data Source=NOTE0113A4\SQLEXPRESS; initial catalog=Rental_Manha; user id=sa; pwd=Senai@132";
        
        //String de Conexão de Casa
        //private string stringConexao = @"Data Source=DESKTOP-NI590A9\SQLEXPRESS; initial catalog=Rental_Manha; user Id=sa; pwd=thiaguinho33";
        public void AtualizarIdCorpo(AluguelDomain AluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE aluguel SET idCliente = @novoCliente, idVeiculo = @novoVeiculo, dataAluguel = @novaData WHERE idAluguel = @idAluguelAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoCliente", AluguelAtualizado.idCliente);
                    cmd.Parameters.AddWithValue("@novoVeiculo", AluguelAtualizado.idVeiculo);
                    cmd.Parameters.AddWithValue("@novaData", AluguelAtualizado.dataAluguel);
                    cmd.Parameters.AddWithValue("@idAluguelAtualizado", AluguelAtualizado.idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int idAluguel, AluguelDomain AluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE aluguel SET idCliente = @novoCliente, idVeiculo = @novoVeiculo, dataAluguel = @novaData WHERE idAluguel = @idAluguelAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoCliente", AluguelAtualizado.idCliente);
                    cmd.Parameters.AddWithValue("@novoVeiculo", AluguelAtualizado.idVeiculo);
                    cmd.Parameters.AddWithValue("@novaData", AluguelAtualizado.dataAluguel);
                    cmd.Parameters.AddWithValue("@idAluguelAtualizado", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idAluguel, cliente.idCliente, nomeCliente, cpfCliente, veiculo.idVeiculo, empresa.idEmpresa, nomeEmpresa, placaVeiculo, dataAluguel FROM aluguel INNER JOIN cliente ON cliente.idCliente = aluguel.idCliente INNER JOIN veiculo ON veiculo.idVeiculo = aluguel.idVeiculo INNER JOIN empresa ON veiculo.idEmpresa = empresa.idEmpresa WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        AluguelDomain AluguelBuscado = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(reader["idAluguel"]),
                            cliente = new ClienteDomain
                            {
                                idCliente = Convert.ToInt32(reader["idCliente"]),
                                nomeCliente = reader["nomeCliente"].ToString(),
                                cpfCliente = Convert.ToInt64(reader["cpfCliente"])
                            },
                            veiculo = new VeiculoDomain
                            {
                                idVeiculo = Convert.ToInt32(reader["idVeiculo"]),
                                empresa = new EmpresaDomain
                                {
                                    idEmpresa = Convert.ToInt32(reader["idEmpresa"]),
                                    nomeEmpresa = reader["nomeEmpresa"].ToString()
                                },
                                placaVeiculo = reader["placaVeiculo"].ToString()
                            },
                            dataAluguel = Convert.ToDateTime(reader["dataAluguel"])
                        };
                        return AluguelBuscado;
                    }
                    return null;
                }
            };
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO aluguel (idCliente, idVeiculo, dataAluguel) VALUES (@idCliente, @idVeiculo, @dataAluguel)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@dataAluguel", novoAluguel.dataAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM aluguel WHERE idAluguel = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> ListaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idAluguel, cliente.idCliente, nomeCliente, cpfCliente, veiculo.idVeiculo, empresa.idEmpresa, nomeEmpresa, placaVeiculo, dataAluguel FROM aluguel INNER JOIN cliente ON cliente.idCliente = aluguel.idCliente INNER JOIN veiculo ON veiculo.idVeiculo = aluguel.idVeiculo INNER JOIN empresa ON veiculo.idEmpresa = empresa.idEmpresa";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AluguelDomain Aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(reader["idAluguel"]),
                            cliente = new ClienteDomain
                            {
                                idCliente = Convert.ToInt32(reader["idCliente"]),
                                nomeCliente = reader["nomeCliente"].ToString(),
                                cpfCliente = Convert.ToInt64(reader["cpfCliente"])
                            },
                            veiculo = new VeiculoDomain
                            {
                                idVeiculo = Convert.ToInt32(reader["idVeiculo"]),
                                empresa = new EmpresaDomain
                                {
                                    idEmpresa = Convert.ToInt32(reader["idEmpresa"]),
                                    nomeEmpresa = reader["nomeEmpresa"].ToString()
                                },
                                placaVeiculo = reader["placaVeiculo"].ToString()
                            },
                            dataAluguel = Convert.ToDateTime(reader["dataAluguel"])
                        };
                        ListaAlugueis.Add(Aluguel);
                    }
                }
            }
            return ListaAlugueis;
        }
    }
}