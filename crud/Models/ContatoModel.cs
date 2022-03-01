using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Digite o nome do contato")]

        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do contato")]
        [EmailAddress (ErrorMessage ="o E-mail informado é invalido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Telefone do contato")]
        [Phone(ErrorMessage =" O telefone inoformado não é valido")]
        public string Telefone { get; set; }
    }
}
