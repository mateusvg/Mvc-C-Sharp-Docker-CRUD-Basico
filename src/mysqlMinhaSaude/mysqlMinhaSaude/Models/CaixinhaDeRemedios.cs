using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mysqlMinhaSaude.Models
{
    public class CaixinhaDeRemedios
    {

        [Key]
        public int id { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        public nomeRemedio nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public TipoRemedio Tipo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Quantidade { get; set; }
    }
    public enum TipoRemedio
    {
        Caixa,
        Cartela,
        Unidade,
    }
    public enum nomeRemedio
    {
        Paracetamol,
        Ibuprofeno,
        Novalgina,
    }
}
