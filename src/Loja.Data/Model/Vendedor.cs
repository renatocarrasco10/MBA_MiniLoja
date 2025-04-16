using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loja.Data.Model
{
    public class Vendedor
    {
        [Key]
        public string? Id { get; set; }

        [Required(ErrorMessage = "O {0} deve ser informado")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O {0} deve ser informado")]
        [Display(Name = "CPF")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O {0} deve conter {2} caracteres")]
        public string? Cpf { get; set; }

        /* EF Relations */
        [JsonIgnore]
        public IEnumerable<Produto>? Produtos { get; set; }
    }
}
