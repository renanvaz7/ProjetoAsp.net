using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SiteSilvio.Models
{
    public class EnderecoModel
    {
        private SqlConnection connection = null;

        public EnderecoModel()
        {
            string strConn = ConfigurationManager.ConnectionStrings["MeuBanco"].ConnectionString;
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Endereco endereco)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO usuario VALUES (@logradouroEnd, @numeroEnd, @bairroEnd, @cidadeEnd, @estadoEnd, @cepEnd, @paisEnd)";

            cmd.Parameters.AddWithValue("@logradouroEnd", endereco.LogradouroEnd);
            cmd.Parameters.AddWithValue("@numeroEnd", endereco.NumeroEnd);
            cmd.Parameters.AddWithValue("@bairroEnd", endereco.BairroEnd);
            cmd.Parameters.AddWithValue("@cidadeEnd", endereco.CidadeEnd);
            cmd.Parameters.AddWithValue("@estadoEnd", endereco.EstadoEnd);
            cmd.Parameters.AddWithValue("@cepEnd", endereco.CepEnd);
            cmd.Parameters.AddWithValue("@paisEnd", endereco.PaisEnd);

            cmd.ExecuteNonQuery();
        }



        public List<Endereco> Read()
        {
            List<Endereco> lista = new List<Endereco>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM endereco";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Endereco endereco = new Endereco();

                endereco.IdEnd = (int)reader["idEnd"];
                endereco.LogradouroEnd = (string)reader["logradouroEnd"];
                endereco.NumeroEnd = (int)reader["numeroEnd"];
                endereco.BairroEnd = (string)reader["bairroEnd"];
                endereco.CidadeEnd = (string)reader["cidadeEnd"];
                endereco.EstadoEnd = (string)reader["estadoEnd"];
                endereco.CepEnd = (string)reader["cepEnd"];
                endereco.PaisEnd = (string)reader["paisEnd"];

                lista.Add(endereco);
            }
            return lista;
        }

        public Endereco ReadUm(int IdRecebido)
        {
            Endereco endereco = new Endereco();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM endereco WHERE idEnd = @IdRecebido";

            cmd.Parameters.AddWithValue("@IdRecebido", IdRecebido);
            SqlDataReader reader = cmd.ExecuteReader();

            endereco.IdEnd = (int)reader["idEnd"];
            endereco.LogradouroEnd = (string)reader["logradouroEnd"];
            endereco.NumeroEnd = (int)reader["numeroEnd"];
            endereco.BairroEnd = (string)reader["bairroEnd"];
            endereco.CidadeEnd = (string)reader["cidadeEnd"];
            endereco.EstadoEnd = (string)reader["estadoEnd"];
            endereco.CepEnd = (string)reader["cepEnd"];
            endereco.PaisEnd = (string)reader["paisEnd"];

            return endereco;
        }



        public void Update(Endereco endereco)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE endereco SET logradouroEnd=@logradouro, numeroEnd=@numero, bairroEnd=@bairro, cidadeEnd=@cidade, estadoEnd=@estado, cepEnd=@cep, paisEnd=@pais WHERE idEnd=@IdEnd";

            SqlDataReader reader = cmd.ExecuteReader();

            cmd.Parameters.AddWithValue("@IdEnd", (int)reader["txtEndId"]);
            cmd.Parameters.AddWithValue("@logradouro", (string)reader["txtLogradouroEnd"]);
            cmd.Parameters.AddWithValue("@numero", (string)reader["txtNumeroEnd"]);
            cmd.Parameters.AddWithValue("@bairro", (string)reader["txtBairroEnd"]);
            cmd.Parameters.AddWithValue("@cidade", (string)reader["txtCidadeEnd"]);
            cmd.Parameters.AddWithValue("@estado", (string)reader["txtEstadoEnd"]);
            cmd.Parameters.AddWithValue("@cep", (string)reader["txtCepEnd"]);
            cmd.Parameters.AddWithValue("@pais", (string)reader["txtPaisEnd"]);

            cmd.ExecuteNonQuery();
        }



        public void Delete(int IdRecebido)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM endereco WHERE idUser=@id_Delete";

            cmd.Parameters.AddWithValue("@id_Delete", IdRecebido);

            cmd.ExecuteNonQuery();
        }
    }
}