using Rental_Manha.Domains;
using Rental_Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Manha.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        //String de Conexão do Senai
        private string stringConexao = @"Data Source=NOTE0113A4\SQLEXPRESS; initial catalog=Rental_Manha; user id=sa; pwd=Senai@132";

        //String de Conexão de Casa
        //private string stringConexao = @"Data Source=DESKTOP-NI590A9\SQLEXPRESS; initial catalog=Rental_Manha; user Id=sa; pwd=thiaguinho33";
        public void AtualizarIdCorpo(EmpresaDomain EmpresaAtualizada)
        {
            if (EmpresaAtualizada.nomeEmpresa != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE empresa SET nomeEmpresa = @novoNomeEmpresa WHERE idEmpresa = @idEmpresaAtualizada";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@novoNomeEmpresa", EmpresaAtualizada.nomeEmpresa);
                        cmd.Parameters.AddWithValue("@idEmpresaAtualizada", EmpresaAtualizada.idEmpresa);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtualizarIdUrl(int idEmpresa, EmpresaDomain EmpresaAtualizada)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE empresa SET nomeEmpresa = @novoNomeEmpresa WHERE idEmpresa = @idEmpresaAtualizada";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeEmpresa", EmpresaAtualizada.nomeEmpresa);
                    cmd.Parameters.AddWithValue("@idEmpresaAtualizada", idEmpresa);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public EmpresaDomain BuscarPorId(int idEmpresa)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idEmpresa, nomeEmpresa FROM empresa WHERE idEmpresa = @idEmpresa";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        EmpresaDomain empresaBuscada = new EmpresaDomain
                        {
                            idEmpresa = Convert.ToInt32(reader["idEmpresa"]),
                            nomeEmpresa = reader["nomeEmpresa"].ToString()
                        };
                        return empresaBuscada;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(EmpresaDomain novaEmpresa)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO empresa (nomeEmpresa) VALUES (@nomeEmpresa)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEmpresa", novaEmpresa.nomeEmpresa);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idEmpresa)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM empresa WHERE idEmpresa = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idEmpresa);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EmpresaDomain> ListarTodos()
        {
            List<EmpresaDomain> ListaEmpresas = new List<EmpresaDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idEmpresa, nomeEmpresa FROM empresa";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EmpresaDomain empresa = new EmpresaDomain()
                        {
                            idEmpresa = Convert.ToInt32(rdr[0]),
                            nomeEmpresa = rdr[1].ToString()
                        };
                        ListaEmpresas.Add(empresa);
                    }
                }
            }
            return ListaEmpresas;
        }
    }
}