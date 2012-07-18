using System;
using Castle.Components.Validator;
using ControleFinanceiro.CORE.Resources;

namespace ControleFinanceiro.CORE.Models
{
    public class Movimento : ModelBase
    {
        [ValidateDateTime(ErrorMessageKey = "InvalidDateTimeMessage", ResourceType = typeof(ValidationsResource))]
        public DateTime DataMovimento { get; set; }

        [ValidateNonEmpty(ErrorMessageKey = "RequiredValueMessage", ResourceType = typeof(ValidationsResource),ExecutionOrder = 1)]
        [ValidateDecimal(ErrorMessageKey = "InvalidDecimalMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 2)]
        public decimal Valor { get; set; }
        
        
        public bool Liquidado { get; set; }

        public string NumeroDocumento { get; set; }

        public bool Parcela { get; set; }


        [ValidateNonEmpty(ErrorMessageKey = "RequiredTIPOPAGAMENTOMessage", ResourceType = typeof(ValidationsResource))]
        public int TipoPagamentoID { get; set; }
        public TipoPagamento TipoPagamento { get; set; }

        [ValidateNonEmpty(ErrorMessageKey = "RequiredCONTAMessage", ResourceType = typeof(ValidationsResource))]
        public int ContaID { get; set; }
        public Conta Conta { get; set; }

        [ValidateNonEmpty(ErrorMessageKey = "RequiredSUBCATEGORIAMessage", ResourceType = typeof(ValidationsResource))]
        public int SubCategoriaID { get; set; }
        public Subcategoria Subcategoria { get; set; }
    }
}
