using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSilvio.Models
{
    public class Produto
    {
        public int CodProd { get; set; }
        public int QuantProd { get; set; }
        public string NomeProd { get; set; }
        public double PrecoProd { get; set; }
        public string DescricaoProd { get; set; }
    }
}