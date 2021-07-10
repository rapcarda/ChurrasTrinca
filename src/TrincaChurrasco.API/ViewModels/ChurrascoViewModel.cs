using System;
using System.ComponentModel.DataAnnotations;

namespace TrincaChurrasco.API.ViewModels
{
    public class ChurrascoViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres")]
        public string Descricao { get; set; }

        [StringLength(300, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres")]
        public string Observacao { get; set; }

        [Range(0, 500, ErrorMessage = "{0} deve ser maior que {1}")]
        public decimal ValorComBebida { get; set; }

        [Range(0, 500, ErrorMessage = "{0} deve ser maior que {1}")]
        public decimal ValorSemBebida { get; set; }
    }
}
