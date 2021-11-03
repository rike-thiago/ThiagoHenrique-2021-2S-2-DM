using InLock_Manha_TT.Domains;
using InLock_Manha_TT.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Manha_TT.Repositories 
{
    public class EstudioRepository : IEstudioRepository 
    {
        //String de Conexão do Senai
        private string stringConexao = @"Data Source=NOTE0113C1\SQLEXPRESS; initial catalog=INLOCK_MANHA_TT; user id=sa; pwd=Senai@132";

        //String de Conexão de Casa
        //private string stringConexao = @"Data Source=DESKTOP-NI590A9\SQLEXPRESS; initial catalog=INLOCK_MANHA_TT; user Id=sa; pwd=thiaguinho33";

        public void AtualizarIdCorpo(EstudioDomain EstudioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE estudio SET nomeEstudio = @novoNomeEstudio WHERE idEstudio = @idEstudioAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeEstudio", EstudioAtualizado.nomeEstudio);
                    cmd.Parameters.AddWithValue("@idEstudioAtualizado", EstudioAtualizado.idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int idEstudio, EstudioDomain EstudioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE estudio SET nomeEstudio = @novoNomeEstudio WHERE idEstudio = @idEstudioAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeEstudio", EstudioAtualizado.nomeEstudio);
                    cmd.Parameters.AddWithValue("@idEstudioAtualizado", idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EstudioDomain BuscarPorId(int idEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT nomeEstudio, idEstudio FROM estudio WHERE idEstudio = @idEstudio";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        EstudioDomain estudioBuscado = new EstudioDomain
                        {
                            idEstudio = Convert.ToInt32(reader["idEstudio"]),

                            nomeEstudio = reader["nomeEstudio"].ToString()
                        };
                        return estudioBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO estudio (nomeEstudio) VALUES (@nomeEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEstudio", novoEstudio.nomeEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM estudio WHERE idEstudio = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idEstudio, nomeEstudio FROM estudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        { 
                            idEstudio = Convert.ToInt32(rdr[0]),

                            nomeEstudio = rdr[1].ToString()
                        };

                        listaEstudio.Add(estudio);
                    }
                }
            }

            return listaEstudio;
        }
    }
}
