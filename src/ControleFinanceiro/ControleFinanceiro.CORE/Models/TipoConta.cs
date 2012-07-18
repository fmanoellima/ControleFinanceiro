using System.Collections.Generic;
using Castle.Components.Validator;
using ControleFinanceiro.CORE.Resources;

namespace ControleFinanceiro.CORE.Models
{
    public class TipoConta : ModelBase
    {
        [ValidateNonEmpty(ErrorMessageKey = "RequiredNameMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 1)]
        [ValidateLength(0, 512, ErrorMessageKey = "InvalidMaxLengthMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 2)]
        public string Nome { get; set; }

        public ICollection<Conta> Contas { get; set; }
    }
}
