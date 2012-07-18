using System.Collections.Generic;
using Castle.Components.Validator;
using ControleFinanceiro.CORE.Resources;

namespace ControleFinanceiro.CORE.Models
{
    public class Conta : ModelBase
    {
       [ValidateNonEmpty(ErrorMessageKey = "RequiredNameMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 1)]
       [ValidateLength(0, 512, ErrorMessageKey = "InvalidMaxLengthMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 2)]
        public string Nome { get; set; }

        [ValidateNonEmpty(ErrorMessageKey = "RequiredTipoContaMessage", ResourceType = typeof(ValidationsResource))]
        public int TipoContaID { get; set; }

        public TipoConta TipoConta { get; set; }

        public ICollection<Movimento> Movimentos { get; set; }

    }
}
