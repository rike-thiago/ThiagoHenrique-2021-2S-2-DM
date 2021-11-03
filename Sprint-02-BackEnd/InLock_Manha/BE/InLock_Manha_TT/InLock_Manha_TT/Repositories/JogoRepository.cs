using InLock_Manha_TT.Domains;
using InLock_Manha_TT.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Manha_TT.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        //String de Conexão do Senai
        private string stringConexao = @"Data Source=NOTE0113C1\SQLEXPRESS; initial catalog=INLOCK_MANHA_TT; user id=sa; pwd=Senai@132";

        //String de Conexão de Casa
        //private string stringConexao = @"Data Source=DESKTOP-NI590A9\SQLEXPRESS; initial catalog=INLOCK_MANHA_TT; user Id=sa; pwd=thiaguinho33";
        public void AtualizarIdCorpo(JogoDomain JogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE jogo SET idEstudio = @novoIdEstudio, nomeJogo = @novoNomeJogo, descricao = @novaDescricao, dataLancamento = @novaDataLancamento, valor = @novoValor WHERE idJogo = @idJogoAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@idJogoAtualizado", JogoAtualizado.idJogo);
                    cmd.Parameters.AddWithValue("@novoIdEstudio", JogoAtualizado.idEstudio);
                    cmd.Parameters.AddWithValue("@novoNomeJogo", JogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@novaDescricao", JogoAtualizado.descricao);
                    cmd.Parameters.AddWithValue("@novaDataLancamento", JogoAtualizado.dataLancamento);
                    cmd.Parameters.AddWithValue("@novoValor", JogoAtualizado.valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int idJogo, JogoDomain JogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE jogo SET idEstudio = @novoIdEstudio, nomeJogo = @novoNomeJogo, descricao = @novaDescricao, dataLancamento = @novaDataLancamento, valor = @novoValor WHERE idJogo = @idJogoAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@idJogoAtualizado", idJogo);
                    cmd.Parameters.AddWithValue("@novoIdEstudio", JogoAtualizado.idEstudio);
                    cmd.Parameters.AddWithValue("@novoNomeJogo", JogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@novaDescricao", JogoAtualizado.descricao);
                    cmd.Parameters.AddWithValue("@novaDataLancamento", JogoAtualizado.dataLancamento);
                    cmd.Parameters.AddWithValue("@novoValor", JogoAtualizado.valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT nomeJogo, idJogo FROM jogo WHERE idJogo = @idJogo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain
                        {
                            idJogo = Convert.ToInt32(reader["idJogo"]),

                            nomeJogo = reader["nomeJogo"].ToString()
                        };
                        return jogoBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO jogo (idEstudio, nomeJogo, descricao, dataLancamento, valor) VALUES (@idEstudio, @nomeJogo, @descricao, @dataLancamento, @valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM jogo WHERE idJogo = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idJogo, nomeJogo FROM jogo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),

                            nomeJogo = rdr[1].ToString()
                        };

                        listaJogo.Add(jogo);
                    }
                    
                }
            }

            return listaJogo;
        }
    }
}