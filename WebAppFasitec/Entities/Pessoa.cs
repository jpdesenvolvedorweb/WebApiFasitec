using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFasitec.Entities
{
    [Table("Pessoas")]
    public class Pessoa
    {

        public Pessoa()
        {
            Contratos = new Collection<Contrato>();
            Faturas = new Collection<Fatura>();
        }

        [Key]
        public int IdPessoa { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!!!")]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O cpf é obrigatório!!!")]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Digite uma data valida por favor!!!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "É necessário informar um dia para que seja realizada a cobrança!!!")]
        [Range(1, 30, ErrorMessage = "O dia de cobrança deve estar entre o dia 1 até o dia 30!!!")]
        public int DiaCobranca { get; set; }

        public ICollection<Contrato> Contratos { get; set; }

        public ICollection<Fatura> Faturas { get; set; }
    }
}
