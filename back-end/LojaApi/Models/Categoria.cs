using System.ComponentModel.DataAnnotations;

namespace LojaAPI.Models{
    public class Categoria{

        [Key]
        public int Id {get; set;}
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(5, ErrorMessage = "O nome deve ter no minimo 5 caracteres")]
        public String Nome {get; set;}

        public String Departamento {get; set;}

        public DateTime DataCadastro {get; set;}
    }
}