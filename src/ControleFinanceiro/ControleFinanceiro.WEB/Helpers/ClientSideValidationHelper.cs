using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Castle.Components.Validator;
using Castle.Components.Validator.Validators;
using ControleFinanceiro.CORE.Helpers;

namespace ControleFinanceiro.Helpers
{
    public static class ClientSideValidationHelper
    {
        /// <summary>
        /// Método que retorna a lista de regras e mensagens utilizadas para validação no JValidate
        /// </summary>
        /// <param name="modelToValidate">Instancia do objeto</param>
        /// <returns>String JSON com as regras e mensagens</returns>
        /// <remarks>O objeto dve estar utilizando notações do Castle Validator</remarks>
        public static string ClientSideValidation(object modelToValidate)
        {
            var results = new StringBuilder();
            var rules = new StringBuilder();
            var messages = new StringBuilder();
            results.Append("{");
            rules.AppendFormat("\"rules\": {0}", "{");
            messages.AppendFormat("\"messages\": {0}", "{");

            var props = TypeDescriptor.GetProperties(modelToValidate.GetType());

            var propCounter = 0;
            foreach (PropertyDescriptor prop in props)
            {
                var generator = new CustomJQueryValidationProvider();
                foreach (var attrib in prop.Attributes.OfType<AbstractValidationAttribute>())
                {
                    var v = attrib.Build();
                    v.ErrorMessage = v.ErrorMessage ?? "*";
                    generator.AddRule(v);
                }

                if (generator.Rules.Count > 0)
                {
                    if (propCounter > 0)
                    {
                        rules.Append(",");
                        messages.Append(",");
                    }
                    rules.AppendFormat("\"{0}\": {1}", prop.Name, "{");
                    messages.AppendFormat("\"{0}\": {1}", prop.Name, "{");

                    for (var i = 0; i < generator.Rules.Count; i++)
                    {
                        var rule = generator.Rules[i];
                        rules.AppendFormat("{0}", rule.GetRuleString());
                        messages.AppendFormat("{0}", rule.GetMessageString());

                        if (i < generator.Rules.Count - 1)
                        {
                            rules.Append(",");
                            messages.Append(",");
                        }
                        else
                        {
                            rules.Append("}");
                            messages.Append("}");
                        }
                    }
                    propCounter++;
                }
            }

            rules.Append("},");
            messages.Append("}");
            results.Append(rules.ToString());
            results.Append(messages.ToString());
            results.Append("}");

            return string.Format("{0}",results.ToString());
        }
    }

    internal class CustomJQueryValidationProvider
    {
        public readonly IList<ValidationRule> Rules = new List<ValidationRule>();

        public void AddRule(object obj)
        {
            switch (obj.GetType().ToString())
            {
                    
                case "Castle.Components.Validator.DateValidator":
                    {
                        var errorMessage = ((DateValidator)(obj)).ErrorMessage;
                        Rules.Add(new ValidationRule(Validate.Date, errorMessage));
                        break;
                    }
                case "Castle.Components.Validator.DateTimeValidator":
                    {
                        
                        var errorMessage = ((DateTimeValidator)(obj)).ErrorMessage;
                        Rules.Add(new ValidationRule(Validate.Date, errorMessage));
                        break;
                    }
                case "Castle.Components.Validator.DecimalValidator":
                    {
                        var errorMessage = ((DecimalValidator)(obj)).ErrorMessage;
                        Rules.Add(new ValidationRule(Validate.Number, errorMessage));
                        break;
                    }
                case "Castle.Components.Validator.DoubleValidator":    
                    {
                        var errorMessage = ((DoubleValidator) (obj)).ErrorMessage;
                        Rules.Add(new ValidationRule(Validate.Number, errorMessage));
                        break;
                    }
                case "Castle.Components.Validator.EmailValidator":
                    {
                        var errorMessage = ((EmailValidator)(obj)).ErrorMessage;
                        Rules.Add(new ValidationRule(Validate.Email, errorMessage));
                        break;
                    }

                case "Castle.Components.Validator.Validators.GuidValidator":
                    {
                        const string regExp = @"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$";
                        var jsonRegExp = regExp.ConvertToJSON();
                        var errorMessage = ((GuidValidator)(obj)).ErrorMessage;
                        Rules.Add(new ValidationRule(Validate.Regex, errorMessage, jsonRegExp));
                        break;
                    }

                case "Castle.Components.Validator.IntegerValidator":
                    {
                        var errorMessage = ((IntegerValidator)(obj)).ErrorMessage;
                        Rules.Add(new ValidationRule(Validate.Digits, errorMessage));
                        break;
                    }

                case"Castle.Components.Validator.LengthValidator":
                    {
                        var errorMessage = ((LengthValidator) (obj)).ErrorMessage;
                        var maxLength = ((LengthValidator)(obj)).MaxLength;
                        var minLength = ((LengthValidator)(obj)).MinLength;
                        var exactLength =((LengthValidator) (obj)).ExactLength;

                        if (minLength <= 0)
                            Rules.Add(new ValidationRule(Validate.Maxlength, string.Format(errorMessage, maxLength), maxLength));
                        else if(exactLength > 0)
                            Rules.Add(new ValidationRule(Validate.RangeLength, string.Format(errorMessage, exactLength), exactLength));
                        else
                            Rules.Add(new ValidationRule(Validate.RangeLength, errorMessage, string.Format("[{0},{1}]", minLength, maxLength)));

                        break;
                    }


                    case "Castle.Components.Validator.NonEmptyValidator":
                    {
                        var errorMessage = ((NonEmptyValidator)(obj)).ErrorMessage;
                        Rules.Add(new ValidationRule(Validate.Required, errorMessage));
                        break;
                    }

                    case "Castle.Components.Validator.NotSameAsValidator":
                    {
                        
                        var errorMessage = ((NotSameAsValidator)(obj)).ErrorMessage;
                        var comparisonFieldName = ((NotSameAsValidator)(obj)).PropertyToCompare;
                        Rules.Add(new ValidationRule(Validate.NotEqualTo, errorMessage, string.Format("\"#{0}\"", comparisonFieldName)));
                        break;
                    }

                    case "Castle.Components.Validator.RegularExpressionValidator":
                    {
                        var errorMessage = ((RegularExpressionValidator)(obj)).ErrorMessage;
                        var regExp = ((RegularExpressionValidator)(obj)).Expression;
                        var jsonRegExp = regExp.ConvertToJSON();
                        Rules.Add(new ValidationRule(Validate.Regex, errorMessage, jsonRegExp));
                        break;
                    }

                    case "Castle.Components.Validator.SameAsValidator":
                    {
                        var errorMessage = ((SameAsValidator)(obj)).ErrorMessage;
                        var comparisonFieldName = ((SameAsValidator)(obj)).PropertyToCompare;
                        Rules.Add(new ValidationRule(Validate.EqualTo, errorMessage, string.Format("\"#{0}\"", comparisonFieldName)));
                        break;
                    }
            }
        }


    }

    internal class ValidationRule
    {
        public ValidationRule(Validate validate) : this(validate, null) { }
        public ValidationRule(Validate validate, string failureMessage): this(validate, failureMessage, null) { }
        public ValidationRule(Validate validate, string failureMessage, object value)
        {
            Validate = validate;
            Value = value;
            if (failureMessage != null)
            {
                ErrorMessage = failureMessage;
            }
            else
            {
                //setup default error messages
                switch (Validate)
                {
                    case Validate.Required:
                        ErrorMessage = "This field is Required";
                        break;
                    default:
                        ErrorMessage = "Field error";
                        break;
                }
            }

        }
        public readonly object Value;
        public readonly Validate Validate;
        public readonly string ErrorMessage;
    }

    enum Validate
    {
        Accept,
        Date,
        Digits,
        Email,
        EqualTo,
        GreaterThan,
        Length,
        Max,
        Maxlength,
        Min,
        Minlength,
        NotEqualTo,
        Number,
        Range,
        RangeLength,
        Regex,
        Required,
        Url
    }

    internal static class JQueryValidationHelper
    {
        public static string GetRuleString(this ValidationRule rule)
        {
            switch (rule.Validate)
            {
                case Validate.Required:
                    return "\"required\" : true";
                case Validate.Email:
                    return "\"email\" : true";
                case Validate.Date:
                    return "\"date\" : true";
                case Validate.Url:
                    return "\"url\" : true";
                case Validate.Number:
                    return "\"number\" : true";
                case Validate.Digits:
                    return "\"digits\" : true";
                case Validate.EqualTo:
                    return string.Format("\"equalTo\" : {0}",rule.Value.ToString());
                default:
                    return string.Format("\"{0}\" : {1}",rule.Validate.ToString().ToLower(),rule.Value.ToString());
            }
        }

        public static string GetMessageString(this ValidationRule rule)
        {
            switch (rule.Validate)
            {
                case Validate.EqualTo:
                    return string.Format("\"equalTo\" : \"{0}\"", rule.ErrorMessage);
                default:
                    return string.Format("\"{0}\" : \"{1}\"", rule.Validate.ToString().ToLower(), rule.ErrorMessage);


            }
        }
    }
}