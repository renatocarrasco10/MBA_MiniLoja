using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace Loja.Data.Model
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} deve ser informado")]
        [Display(Name = "Nome")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres")]
        public string? Nome { get; set; }
       
        [Required(ErrorMessage = "O {0} deve ser informado")]
        [Display(Name = "Descrição")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres")]
        public string? Descricao { get; set; }

        [Display(Name = "Imagem")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string? ImagemUrl { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, int.MaxValue, ErrorMessage = "O {0} deve estar entre {1} e {2}")]
        public decimal Preco { get; set; }
       
        [Required(ErrorMessage = "A {0} deve ser informada")]
        [Display(Name = "Qtd. Estoque")]
        [Range(0, int.MaxValue, ErrorMessage = "O {0} deve estar entre {1} e {2}")]
        public int QuantidadeEstoque { get; set; }

        public bool Ativo { get; set; }
            
        public DateTime? DataCadastro { get; set; }

        [Required(ErrorMessage = "A {0} deve ser informada")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public string? VendedorId { get; set; }

        /* EF Relations */
        public Vendedor? Vendedor { get; set; }
        public virtual Categoria? Categoria { get; set; }

        [NotMapped]
        public IFormFile? Imagem { get; set; }

    }
}




