using System.ComponentModel.DataAnnotations;


namespace Loja.Data.Model
{
    public class Categoria
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        /* EF Relations */
        public IEnumerable<Produto>? Produtos { get; set; }
    }
}
