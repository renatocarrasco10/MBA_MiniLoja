using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Loja.Data.Model
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O {0} deve ser informado")]
        [Display(Name = "Descrição")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres")]
        public string? Descricao { get; set; }

        /* EF Relations */
        [JsonIgnore]
        public IEnumerable<Produto>? Produtos { get; set; }
    }
}
