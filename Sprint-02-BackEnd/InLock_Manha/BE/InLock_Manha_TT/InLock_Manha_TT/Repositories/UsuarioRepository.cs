﻿using InLock_Manha_TT.Domains;
using InLock_Manha_TT.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Manha_TT.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //String de Conexão do Senai
        private string stringConexao = @"Data Source=NOTE0113C1\SQLEXPRESS; initial catalog=INLOCK_MANHA_TT; user id=sa; pwd=Senai@132";

        //String de Conexão de Casa
        //private string stringConexao = @"Data Source=DESKTOP-NI590A9\SQLEXPRESS; initial catalog=INLOCK_MANHA_TT; user Id=sa; pwd=thiaguinho33";

        public void AtualizarIdCorpo(UsuarioDomain UsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE usuario SET idTipoUsuario = @novoIdTipoUsuario, email = @novoEmail, nomeUsuario = @novoNomeUsuario, senha = @novaSenha WHERE idUsuario = @idUsuarioAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoIdTipoUsuario", UsuarioAtualizado.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@novoEmail", UsuarioAtualizado.email);
                    cmd.Parameters.AddWithValue("@novoNomeUsuario", UsuarioAtualizado.nomeUsuario);
                    cmd.Parameters.AddWithValue("@novaSenha", UsuarioAtualizado.senha);
                    cmd.Parameters.AddWithValue("@idUsuarioAtualizado", UsuarioAtualizado.idUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int idUsuario, UsuarioDomain UsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE usuario SET idTipoUsuario = @novoIdTipoUsuario, email = @novoEmail, nomeUsuario = @novoNomeUsuario, senha = @novaSenha WHERE idUsuario = @idUsuarioAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoIdTipoUsuario", UsuarioAtualizado.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@novoEmail", UsuarioAtualizado.email);
                    cmd.Parameters.AddWithValue("@novoNomeUsuario", UsuarioAtualizado.nomeUsuario);
                    cmd.Parameters.AddWithValue("@novaSenha", UsuarioAtualizado.senha);
                    cmd.Parameters.AddWithValue("@idUsuarioAtualizado", idUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = @"SELECT  idUsuario, idTipoUsuario, email, senha FROM usuario WHERE email  = @email AND senha = @senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString()
                        };
                        return usuarioBuscado;
                    }
                    return null;
                }
            }
        }

        public UsuarioDomain BuscarPorId(int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT nomeUsuario, idUsuario FROM usuario WHERE idUsuario = @idUsuario";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),

                            nomeUsuario = reader["nomeUsuario"].ToString()
                        };
                        return usuarioBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO usuario (idTipoUsuario, email, nomeUsuario, senha) VALUES (@idTipoUsuario, @email, @nomeUsuario, @senha)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idTipoUsuario", novoUsuario.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@email", novoUsuario.email);
                    cmd.Parameters.AddWithValue("@nomeUsuario", novoUsuario.nomeUsuario);
                    cmd.Parameters.AddWithValue("@senha", novoUsuario.senha);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM usuario WHERE idUsuario = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> ListarTodos()
        {
            List<UsuarioDomain> listaUsuario = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idUsuario, nomeUsuario FROM usuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),

                            nomeUsuario = rdr[1].ToString()
                        };

                        listaUsuario.Add(usuario);
                    }
                }
            }

            return listaUsuario;
        }
    }
}
