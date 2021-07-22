using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSilvio.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public Produto CodProduto { get; set; }
        public int QuantPedido { get; set; }
        public double TotalPedido { get; set; }
        public Usuario IdUsuario { get; set; }
        public Endereco IdEndereco { get; set; }
    }
}