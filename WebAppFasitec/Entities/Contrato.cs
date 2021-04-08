using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFasitec.Entities
{
        [Table("Contratos")]
        public class Contrato
        {
            public Contrato()
            {
                Parcelas = new Collection<Parcela>();
            }

            [Key]
            public int IdContrato { get; set; }

            [Required(ErrorMessage = "O numero do contrato é obrigatório informar!!!")]
            public int NumeroContrato { get; set; }

            [Required(ErrorMessage = "O banco é obrigatório informar!!!")]
            public string Banco { get; set; }

            [Required(ErrorMessage = "O valor é obrigatório informar!!!")]
            public decimal Valor { get; set; }

            [Required(ErrorMessage = "A quantidade de parcelas é obrigatório informar!!!")]
            public int QtdeParcelas { get; set; }

            [Required(ErrorMessage = "É obrigatório informar a data de cadastro!!!")]
            public DateTime Datacadastro { get; set; }

            public Pessoa Pessoas { get; set; }

            public int IdPessoa { get; set; }

            public ICollection<Parcela> Parcelas { get; set; }
        }

}
