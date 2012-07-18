using Castle.Components.Validator;
using System.Collections.Generic;
using ControleFinanceiro.CORE.Resources;

namespace ControleFinanceiro.CORE.Models
{
    public class Subcategoria : ModelBase
    {


        [ValidateNonEmpty(ErrorMessageKey = "RequiredNameMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 1)]
        [ValidateLength(0, 512, ErrorMessageKey = "InvalidMaxLengthMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 2)]
        public string Nome { get; set; }

        public bool Favorito { get; set; }

        [ValidateNonEmpty(ErrorMessageKey = "RequiredCATEGORIAMessage", ResourceType = typeof(ValidationsResource))]
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }

        public ICollection<Movimento> Movimentos { get; set; }
    }
}
