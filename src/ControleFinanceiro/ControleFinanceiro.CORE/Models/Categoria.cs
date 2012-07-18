using System.Collections.Generic;
using Castle.Components.Validator;
using ControleFinanceiro.CORE.Resources;

namespace ControleFinanceiro.CORE.Models
{
    public class Categoria : ModelBase
    {
        [ValidateNonEmpty(ErrorMessageKey = "RequiredNameMessage", ResourceType = typeof(ValidationsResource))]
        public string Nome { get; set; }

        public ICollection<Subcategoria> SubCategorias { get; set; }
    }
}
