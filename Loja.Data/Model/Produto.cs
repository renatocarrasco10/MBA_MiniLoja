using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Loja.Data.Model.Vendedores;   


namespace Loja.Data.Model
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} deve ser informado")]
        [Display(Name = "Nome")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Nome { get; set; }
       
        [Required(ErrorMessage = "O {0} deve ser informado")]
        [Display(Name = "Descrição")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Descricao { get; set; }
        
        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 99999.99, ErrorMessage = "O {0} deve estar entre {1} e {2}")]
        public decimal Preco { get; set; }
       
        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string? ImagemUrl { get; set; }

        [Required(ErrorMessage = "A {0} deve ser informada")]
        [Display(Name = "Quantidade em Estoque")]
        [Range(0, 99999, ErrorMessage = "O {0} deve estar entre {1} e {2}")]
        public int QuantidadeEstoque { get; set; }
        public bool Ativo { get; set; }

        
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "A {0} deve ser informada")]
        [Display(Name = "Categoria")]
        public Guid CategoriaId { get; set; }
        public Guid VendedorId { get; set; }

        /* EF Relations */
        public Vendedor? Vendedor { get; set; }
        public virtual Categoria? Categoria { get; set; }

    }
}




