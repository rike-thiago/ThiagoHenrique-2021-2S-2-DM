using Rental_Manha.Domains;
using Rental_Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Manha.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        //String de Conexão do Senai
        private string stringConexao = @"Data Source=NOTE0113A4\SQLEXPRESS; initial catalog=Rental_Manha; user id=sa; pwd=Senai@132";

        //String de Conexão de Casa
        //private string stringConexao = @"Data Source=DESKTOP-NI590A9\SQLEXPRESS; initial catalog=Rental_Manha; user Id=sa; pwd=thiaguinho33";
        public void AtualizarIdCorpo(VeiculoDomain VeiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE veiculo SET idModelo = @novoModelo, idMarca = @novaMarca, placaVeiculo = @novaPlacaVeiculo, idEmpresa = @novaEmpresaVeiculo WHERE idVeiculo = @idVeiculoAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoModelo", VeiculoAtualizado.idModelo);
                    cmd.Parameters.AddWithValue("@novaMarca", VeiculoAtualizado.idMarca);
                    cmd.Parameters.AddWithValue("@novaPlacaVeiculo", VeiculoAtualizado.placaVeiculo);
                    cmd.Parameters.AddWithValue("@novaEmpresaVeiculo", VeiculoAtualizado.idEmpresa);
                    cmd.Parameters.AddWithValue("@idVeiculoAtualizado", VeiculoAtualizado.idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain VeiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE veiculo SET idModelo = @novoModelo, idMarca = @novaMarca, placaVeiculo = @novaPlacaVeiculo, idEmpresa = @novaEmpresaVeiculo WHERE idVeiculo = @idVeiculoAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoModelo", VeiculoAtualizado.idModelo);
                    cmd.Parameters.AddWithValue("@novaMarca", VeiculoAtualizado.idMarca);
                    cmd.Parameters.AddWithValue("@novaPlacaVeiculo", VeiculoAtualizado.placaVeiculo);
                    cmd.Parameters.AddWithValue("@novaEmpresaVeiculo", VeiculoAtualizado.idEmpresa);
                    cmd.Parameters.AddWithValue("@idVeiculoAtualizado", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idVeiculo, isnull(veiculo.idModelo,0)idModelo, isnull(veiculo.idMarca,0)idMarca, nomeModelo, nomeMarca, empresa.idEmpresa, nomeEmpresa, placaVeiculo FROM veiculo INNER JOIN modelo ON veiculo.idModelo = modelo.idModelo INNER JOIN marca ON veiculo.idMarca = marca.idMarca INNER JOIN empresa ON veiculo.idEmpresa = empresa.idEmpresa WHERE idVeiculo = @idVeiculoBuscado";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculoBuscado", idVeiculo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        VeiculoDomain VeiculoBuscado = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),
                            placaVeiculo = reader["placaVeiculo"].ToString(),
                            modelo = new ModeloDomain
                            {
                                idModelo = Convert.ToInt32(reader["idModelo"]),
                                nomeModelo = reader["nomeModelo"].ToString(),
                                marca = new MarcaDomain
                                {
                                    idMarca = Convert.ToInt32(reader["idMarca"]),
                                    nomeMarca = reader["nomeMarca"].ToString()
                                }
                            },
                            
                            empresa = new EmpresaDomain
                            {
                                idEmpresa = Convert.ToInt32(reader["idEmpresa"]),
                                nomeEmpresa = reader["nomeEmpresa"].ToString()
                            }
                        };
                        return VeiculoBuscado;
                    }
                    return null;
                }
            };
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO veiculo (idEmpresa, idModelo, idMarca, placaVeiculo) VALUES (@idEmpresa, @idModelo, @idMarca, @placaVeiculo)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@idEmpresa", novoVeiculo.idEmpresa);
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@idMarca", novoVeiculo.idMarca);
                    cmd.Parameters.AddWithValue("@placaVeiculo", novoVeiculo.placaVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM veiculo WHERE idVeiculo = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> ListaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idVeiculo, idModelo, idMarca, empresa.idEmpresa, nomeEmpresa, placaVeiculo FROM veiculo INNER JOIN empresa ON veiculo.idEmpresa = empresa.idEmpresa";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        VeiculoDomain VeiculoBuscado = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),
                            placaVeiculo = reader["placaVeiculo"].ToString(),
                            modelo = new ModeloDomain
                            {
                                idModelo = Convert.ToInt32(reader["idModelo"]),
                                nomeModelo = reader["nomeModelo"].ToString(),
                                marca = new MarcaDomain
                                {
                                    idMarca = Convert.ToInt32(reader["idMarca"]),
                                    nomeMarca = reader["nomeMarca"].ToString()
                                }
                            },

                            empresa = new EmpresaDomain
                            {
                                idEmpresa = Convert.ToInt32(reader["idEmpresa"]),
                                nomeEmpresa = reader["nomeEmpresa"].ToString()
                            }
                        };
                        ListaVeiculos.Add(VeiculoBuscado);
                    }
                }
            }
            return ListaVeiculos;
        }
    }
}