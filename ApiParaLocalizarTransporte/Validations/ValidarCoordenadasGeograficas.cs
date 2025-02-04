using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ApiParaLocalizarTransporte.Validations
{
    public class ValidarCoordenadasGeograficas : ValidationAttribute
    {
        //protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        //{
        //    if (value == null || string.IsNullOrEmpty(value.ToString()))
        //    {
        //        return new ValidationResult("As coordenadas não pode ser vazia");
        //    }

        //    string regex = @"([-?90-90])+([\.,])+([0-9]{7})";
        //    //string regex = @"^(-?(90|[0-8]?\d)(\.\d{1,7})?)$";

        //    string coordenada = value.ToString();

        //    Match result = Regex.Match(coordenada, regex);

         

        //    if (result.Success)
        //    {
        //        return ValidationResult.Success;
        //    }

        //    return new ValidationResult("As coordenadas estão inválidas");
        //}
    }
}
