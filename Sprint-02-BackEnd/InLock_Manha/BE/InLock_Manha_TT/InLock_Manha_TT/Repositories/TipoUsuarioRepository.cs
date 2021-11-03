using InLock_Manha_TT.Domains;
using InLock_Manha_TT.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Manha_TT.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        //String de Conexão do Senai
        private string stringConexao = @"Data Source=NOTE0113C1\SQLEXPRESS; initial catalog=INLOCK_MANHA_TT; user id=sa; pwd=Senai@132";

        //String de Conexão de Casa
        //private string stringConexao = @"Data Source=DESKTOP-NI590A9\SQLEXPRESS; initial catalog=INLOCK_MANHA_TT; user Id=sa; pwd=thiaguinho33";

        public void AtualizarIdCorpo(TipoUsuarioDomain TipoUsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE tipoUsuario SET titulo = @novoTitulo WHERE idTipoUsuario = @idTipoUsuarioAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@idTipoUsuarioAtualizado", TipoUsuarioAtualizado.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@novoTitulo", TipoUsuarioAtualizado.titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int idTipoUsuario, TipoUsuarioDomain TipoUsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE tipoUsuario SET titulo = @novoTitulo WHERE idTipoUsuario = @idTipoUsuarioAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@idTipoUsuarioAtualizado", idTipoUsuario);
                    cmd.Parameters.AddWithValue("@novoTitulo", TipoUsuarioAtualizado.titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TipoUsuarioDomain BuscarPorId(int idTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT titulo, idTipoUsuario FROM tipoUsuario WHERE idTipoUsuario = @idTipoUsuario";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idTipoUsuario", idTipoUsuario);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        TipoUsuarioDomain tipoUsuarioBuscado = new TipoUsuarioDomain
                        {
                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                            titulo = reader["titulo"].ToString()
                        };
                        return tipoUsuarioBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(TipoUsuarioDomain novoTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO tipoUsuario (titulo) VALUES (@titulo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@titulo", novoTipoUsuario.titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM tipoUsuario WHERE idTipoUsuario = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TipoUsuarioDomain> ListarTodos()
        {
            List<TipoUsuarioDomain> listaTipoUsuario = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idTipoUsuario, titulo FROM tipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(rdr[0]),

                            titulo = rdr[1].ToString()
                        };

                        listaTipoUsuario.Add(tipoUsuario);
                    }

                }
            }

            return listaTipoUsuario;
        }
    }
}
