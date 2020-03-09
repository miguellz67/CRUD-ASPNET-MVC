using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteWeb.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public int Identificacao { get; set; }
        
    }
}