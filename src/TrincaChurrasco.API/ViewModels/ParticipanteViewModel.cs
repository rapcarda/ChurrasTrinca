using System;
using System.ComponentModel.DataAnnotations;

namespace TrincaChurrasco.API.ViewModels
{
    public class ParticipanteViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ChurrascoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, 500, ErrorMessage = "{0} deve ser maior que {1}")]
        public decimal Valor { get; set; }
    }
}
