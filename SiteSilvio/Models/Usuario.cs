using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSilvio.Models
{
    public class Usuario
    {
        public int IdUser { get; set; }
        public string NomeUser { get; set; }
        public string EmailUser { get; set; }
        public string PasswordUser { get; set; }
        public string TelUser { get; set; }
        public Endereco EnderecoUser { get; set; }
    }
}