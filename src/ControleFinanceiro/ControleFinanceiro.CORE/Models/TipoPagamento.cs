using Castle.Components.Validator;
using System.Collections.Generic;
using ControleFinanceiro.CORE.Resources;

namespace ControleFinanceiro.CORE.Models
{
    public class TipoPagamento : ModelBase
    {
        [ValidateNonEmpty(ErrorMessageKey = "RequiredNameMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 1)]
        [ValidateLength(0, 512, ErrorMessageKey = "InvalidMaxLengthMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 2)]
        public string Nome { get; set; }

        public ICollection<Movimento> Movimentos { get; set; }
    }
}
