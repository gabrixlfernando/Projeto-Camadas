using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCamdas.DTO
{
    public class FuncionarioDTO
    {
        public int IdFuncionario { get; set; }
        public string NomeFuncionario { get; set; }
        public string EmailFuncionario { get; set; }
        public string SenhaFuncionario { get; set; }
        public DateTime DtNascFuncionario { get; set; }
        public string UrlImgFuncionario { get; set; }
        public string CPF { get; set; }
        public string TelefoneFuncionario { get; set; }
        public string Sexo { get; set; }
        public int TpFuncionario { get; set; }

        public TipoFuncionarioDTO TipoFuncionario { get; set; }
    }
}
