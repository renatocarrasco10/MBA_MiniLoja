using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Data.Model.Vendedores
{
    public class Vendedor
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O {0} deve ser informado")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O {0} deve ser informado")]
        [Display(Name = "CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O {0} deve conter {2} caracteres")]
        public string? Cpf { get; set; }

        public bool Ativo { get; set; }

        /* EF Relations */
        public TipoVendedor TipoVendedor { get; set; }
        public Endereco? Endereco { get; set; }
        public IEnumerable<Produto>? Produtos { get; set; }
    }
}
