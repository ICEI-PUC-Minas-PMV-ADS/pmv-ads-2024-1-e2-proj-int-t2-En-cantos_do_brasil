using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encantos_do_Brasil.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Insira seu nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira seu nome de usuário!")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Insira seu email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira sua senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage ="Obrigatório informar o perfil!")]
        public Perfil Perfil { get; set; }

    }

    public enum Perfil
    {
        Admin,
        User
    }
}
