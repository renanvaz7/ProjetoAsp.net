using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SiteSilvio.Models
{
    public class ProdutoModel 
    { 


        private SqlConnection connection = null;

        public ProdutoModel()
        {
            string strConn = ConfigurationManager.ConnectionStrings["MeuBanco"].ConnectionString;
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Produto produto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO produto VALUES (@quantprod, @nomeProd, @precoProd, @descricaoProd)";

            cmd.Parameters.AddWithValue("@quantProd", produto.QuantProd);
            cmd.Parameters.AddWithValue("@nomeProd", produto.NomeProd);
            cmd.Parameters.AddWithValue("@precoProd", produto.PrecoProd);
            cmd.Parameters.AddWithValue("@descricaoProd", produto.DescricaoProd);

            cmd.ExecuteNonQuery();
        }



        public List<Produto> Read()
        {
            List<Produto> lista = new List<Produto>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM produto";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Produto produto = new Produto();

                produto.CodProd = (int)reader["codProdd"];
                produto.QuantProd = (int)reader["quantprod"];
                produto.NomeProd = (string)reader["nomeProd"];
                produto.PrecoProd = (float)reader["precoProd"];
                produto.DescricaoProd = (string)reader["descricaoProd"];

                lista.Add(produto);
            }
            return lista;
        }

        public Produto ReadUm(int IdRecebido)
        {
            Produto produto = new Produto();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM produto WHERE codProd = @IdRecebido";

            cmd.Parameters.AddWithValue("@IdRecebido", IdRecebido);
            SqlDataReader reader = cmd.ExecuteReader();

            produto.CodProd = (int)reader["codProd"];
            produto.QuantProd = (int)reader["quantProd"];
            produto.NomeProd = (string)reader["NomeProd"];
            produto.PrecoProd = (float)reader["precoProd"];
            produto.DescricaoProd = (string)reader["descricaoProd"];

            return produto;
        }



        public void Update(Produto produto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE produto SET quantprod=@qtd, nomeProd=@nome, precoProd=@preco, descricaoProd=@descricao WHERE codProd=@idProd";

            SqlDataReader reader = cmd.ExecuteReader();

            cmd.Parameters.AddWithValue("@idProd", (int)reader["txtCodProd"]);
            cmd.Parameters.AddWithValue("@qtd", (int)reader["txtQuantProd"]);
            cmd.Parameters.AddWithValue("@nome", (string)reader["txtNomeProd"]);
            cmd.Parameters.AddWithValue("@preco", (float)reader["txtPrecoProd"]);
            cmd.Parameters.AddWithValue("@descricao", (string)reader["txtDescricaoProd"]);            

            cmd.ExecuteNonQuery();
        }



        public void Delete(int IdRecebido)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM produto WHERE idUser=@id_Delete";

            cmd.Parameters.AddWithValue("@id_Delete", IdRecebido);

            cmd.ExecuteNonQuery();
        }
    }
}