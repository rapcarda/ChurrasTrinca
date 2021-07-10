using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrincaChurrasco.API.Application.Commands.CriarChurrasco
{
    public class CriarChurrascoResponse
    {
        public Guid Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public decimal ValorComBebida { get; set; }
        public decimal ValorSemBebida { get; set; }

        public CriarChurrascoResponse(Guid id, DateTime dataHora, string descricao, string observacao, decimal valorComBebida, decimal valorSemBebida)
        {
            Id = id;
            DataHora = dataHora;
            Descricao = descricao;
            Observacao = observacao;
            ValorComBebida = valorComBebida;
            ValorSemBebida = valorSemBebida;
        }
    }
}
