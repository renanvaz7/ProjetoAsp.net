using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SiteSilvio.Models
{
    public class PedidoModel
    {
        private SqlConnection connection = null;

        public PedidoModel()
        {
            string strConn = ConfigurationManager.ConnectionStrings["MeuBanco"].ConnectionString;
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Pedido pedido)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO pedido VALUES (@codProduto, @quantPedido, @totalPedido, @idUsuario, @idEndereco)";

            cmd.Parameters.AddWithValue("@codProduto", pedido.CodProduto);
            cmd.Parameters.AddWithValue("@quantPedido", pedido.QuantPedido);
            cmd.Parameters.AddWithValue("@totalPedido", pedido.TotalPedido);
            cmd.Parameters.AddWithValue("@idUsuario", pedido.IdUsuario);
            cmd.Parameters.AddWithValue("@idEndereco", pedido.IdEndereco);

            cmd.ExecuteNonQuery();
        }



        public List<Pedido> Read()
        {
            List<Pedido> lista = new List<Pedido>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM pedido";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Pedido pedido = new Pedido();

                pedido.IdPedido = (int)reader["idPedido"];
                pedido.CodProduto = (Produto)reader["codProduto"];
                pedido.QuantPedido = (int)reader["quantPedido"];
                pedido.TotalPedido = (float)reader["totalPedido"];
                pedido.IdUsuario = (Usuario)reader["idUsuario"];
                pedido.IdEndereco = (Endereco)reader["idEndereco"];

                lista.Add(pedido);
            }
            return lista;
        }

        public Pedido ReadUm(int IdRecebido)
        {
            Pedido pedido = new Pedido();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM pedido WHERE idPedido = @IdRecebido";

            cmd.Parameters.AddWithValue("@IdRecebido", IdRecebido);
            SqlDataReader reader = cmd.ExecuteReader();

            pedido.IdPedido = (int)reader["codProd"];
            pedido.CodProduto = (Produto)reader["codProduto"];
            pedido.QuantPedido = (int)reader["quantPedido"];
            pedido.TotalPedido = (float)reader["totalPedido"];
            pedido.IdUsuario = (Usuario)reader["idUsuario"];
            pedido.IdEndereco = (Endereco)reader["idEndereco"];

            return pedido;
        }



        public void Update(Pedido pedido)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE pedido SET codProduto=@cod, quantPedido=@qtd, totalPedido=@total, idUsuario=@idU, idEndereco=@idE WHERE idPedido=@idP";

            SqlDataReader reader = cmd.ExecuteReader();

            cmd.Parameters.AddWithValue("@idP", (int)reader["txtIdPedido"]);
            cmd.Parameters.AddWithValue("@cod", (Produto)reader["txtCodProduto"]);
            cmd.Parameters.AddWithValue("@qtd", (int)reader["txtQuantPedido"]);
            cmd.Parameters.AddWithValue("@total", (float)reader["txtTotatlPedido"]);
            cmd.Parameters.AddWithValue("@idU", (Usuario)reader["txtIdUsuario"]);
            cmd.Parameters.AddWithValue("@idE", (Endereco)reader["txtIdEndereco"]);

            cmd.ExecuteNonQuery();
        }



        public void Delete(int IdRecebido)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM pedido WHERE idPedido=@id_Delete";

            cmd.Parameters.AddWithValue("@id_Delete", IdRecebido);

            cmd.ExecuteNonQuery();
        }
    }
}