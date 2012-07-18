using System;
using Castle.Components.Validator;
using ControleFinanceiro.CORE.Resources;

namespace ControleFinanceiro.CORE.Models
{
    public abstract class ModelBase
    {
        public int ID { get; set; }


        [ValidateGuid(false, ErrorMessageKey = "InvalidUserIdMessage", ResourceType = typeof(ValidationsResource))]
        public Guid Usuario { get; set; }

        [ValidateLength(0, 512, ErrorMessageKey = "InvalidMaxLengthMessage", ResourceType = typeof(ValidationsResource))]
        public string Descricao { get; set; }

        [ValidateDate(ErrorMessageKey = "InvalidDateTimeMessage", ResourceType = typeof(ValidationsResource))]
        public DateTime DataCadastro { get; set; }

        [ValidateDate(ErrorMessageKey = "InvalidDateTimeMessage", ResourceType = typeof(ValidationsResource))]
        public DateTime? DataAlteracao { get; set; }

    }
}
