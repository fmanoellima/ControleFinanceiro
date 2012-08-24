using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.DAL.Entities
{
    [Table("Movimentos")]
    public class Movimento : EntityBase
    {

        public DateTime DataMovimento { get; set; }

        public decimal Valor { get; set; }

        public bool Liquidado { get; set; }

        public string NumeroDocumento { get; set; }

        public bool Parcela { get; set; }

        [ForeignKey("TipoPagamento")]
        public int TipoPagamentoID { get; set; }
        public virtual TipoPagamento TipoPagamento { get; set; }

        [ForeignKey("Conta")]
        public int ContaID { get; set; }
        public virtual Conta Conta { get; set; }

        [ForeignKey("Subcategoria")]
        public int SubCategoriaID { get; set; }
        public virtual Subcategoria Subcategoria { get; set; }
    }
}
