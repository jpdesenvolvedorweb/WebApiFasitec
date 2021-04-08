using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFasitec.Entities
{
    [Table("Faturas")]
    public class Fatura
    {
        public Fatura()
        {
            Parcelas = new Collection<Parcela>();
        }

        [Key]
        public int IdFatura { get; set; }

        [Required(ErrorMessage = "Informe uma data valida para o fechamento!!!")]
        public DateTime DataFechamento { get; set; }

        [Required(ErrorMessage = "Deve ter um valor definido!!!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o valor pago!!!")]
        public decimal ValorPago { get; set; }

        public DateTime? DataPagamento { get; set; }

        public bool Pago { get; set; }

        public Pessoa Pessoas { get; set; }

        public int IdPessoa { get; set; }

        public ICollection<Parcela> Parcelas { get; set; }
    }
}
