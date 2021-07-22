using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SiteSilvio.Models
{
    public class UsuarioModel
    {
        private SqlConnection connection = null;

        public UsuarioModel()
        {
            string strConn = ConfigurationManager.ConnectionStrings["MeuBanco"].ConnectionString;
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO usuario VALUES (@nomeUser, @emailUser, @passwordUser, @telUser, @enderecoUser)";

            cmd.Parameters.AddWithValue("@nomeUser", usuario.NomeUser);
            cmd.Parameters.AddWithValue("@emailUser", usuario.EmailUser);
            cmd.Parameters.AddWithValue("@passwordUser", usuario.PasswordUser);
            cmd.Parameters.AddWithValue("@telUser", usuario.TelUser);
            cmd.Parameters.AddWithValue("@enderecoUser", usuario.EnderecoUser);

            cmd.ExecuteNonQuery();
        }



        public List<Usuario> Read()
        {
            List<Usuario> lista = new List<Usuario>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM usuario";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Usuario usuario = new Usuario();

                usuario.IdUser = (int)reader["idUser"];
                usuario.NomeUser = (string)reader["nomeUser"];
                usuario.EmailUser = (string)reader["emailUser"];
                usuario.PasswordUser = (string)reader["passwordUser"];
                usuario.TelUser = (string)reader["telUser"];
                usuario.EnderecoUser = (Endereco)reader["enderecoUser"];

                lista.Add(usuario);
            }
            return lista;
        }

        public Usuario ReadUm(int IdRecebido)
        {
            Usuario usuario = new Usuario();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM usuario WHERE idUser = @IdRecebido";

            cmd.Parameters.AddWithValue("@IdRecebido", IdRecebido);
            SqlDataReader reader = cmd.ExecuteReader();

            usuario.IdUser = (int)reader["idUser"];
            usuario.NomeUser = (string)reader["nomeUser"];
            usuario.EmailUser = (string)reader["emailUser"];
            usuario.PasswordUser = (string)reader["passwordUser"];
            usuario.TelUser = (string)reader["telUser"];
            usuario.EnderecoUser = (Endereco)reader["enderecoUser"];

            return usuario;
        }



        public void Update(Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE usuario SET nomeUser=@nome, emailUser=@email, passwordUser=@password, telUser=@tel, enderecoUser=@endereco WHERE idUser=@IdUsuario";

            SqlDataReader reader = cmd.ExecuteReader();

            cmd.Parameters.AddWithValue("@IdUsuario", (int)reader["txtIdUser"]);
            cmd.Parameters.AddWithValue("@nome", (string)reader["txtNomeUser"]);
            cmd.Parameters.AddWithValue("@email", (string)reader["txtEmailUser"]);
            cmd.Parameters.AddWithValue("@password", (string)reader["txtPasswordUser"]);
            cmd.Parameters.AddWithValue("@tel", (string)reader["txtTelUser"]);
            cmd.Parameters.AddWithValue("@endereco", (Endereco)reader["txtEnderecoUser"]);

            cmd.ExecuteNonQuery();
        }



        public void Delete(int IdRecebido)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM usuario WHERE idUser=@id_Delete";

            cmd.Parameters.AddWithValue("@id_Delete", IdRecebido);

            cmd.ExecuteNonQuery();
        }
    }
}