using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFasitec.Entities
{
    [Table("Parcelas")]
    public class Parcela
    {
        [Key]
        public int IdParcela { get; set; }

        [Required]
        public int NumeroParcela { get; set; }

        [Required]
        public decimal Valor { get; set; }

        public DateTime? DataFechamento { get; set; }

        public Contrato Contrato { get; set; }

        public int IdContrato { get; set; }

        public Fatura Fatura { get; set; }

        public int? IdFatura { get; set; }
    }
}
