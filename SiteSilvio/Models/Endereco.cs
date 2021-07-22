using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSilvio.Models
{
    public class Endereco
    {
        public int IdEnd{ get; set; }
        public string LogradouroEnd { get; set; }
        public int NumeroEnd { get; set; }
        public string BairroEnd { get; set; }
        public string CidadeEnd { get; set; }
        public string EstadoEnd  { get; set; }
        public string CepEnd { get; set; }
        public string PaisEnd { get; set; }
    }
}