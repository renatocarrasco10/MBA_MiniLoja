using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Data.Model.Vendedores
{
    public class Endereco 
    {
        [Key]
        public int Id { get; set; }
        public Guid VendedorId { get; set; }

        [Required(ErrorMessage = "O {0} deve ser informado")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Logradouro { get; set; }

        [Required(ErrorMessage = "O {0} deve ser informado")]
        [Display(Name = "Número")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Numero { get; set; }

        public string? Complemento { get; set; }


        [Required(ErrorMessage = "O {0} deve ser informado")]
        [Display(Name = "CEP")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} deve conter {2} caracteres")]
        public string? Cep { get; set; }


        [Required(ErrorMessage = "O {0} deve ser informado")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Bairro { get; set; }

        [Required(ErrorMessage = "O {0} deve ser informado")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "O {0} deve ser informado")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Estado { get; set; }

        /* EF Relation */
        public Vendedor? Vendedor { get; set; }
    }
}
