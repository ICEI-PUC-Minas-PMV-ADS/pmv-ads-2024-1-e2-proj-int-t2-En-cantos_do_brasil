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

        [Required(ErrorMessage = "Insira seu email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira sua senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Preferência")]
        [Required(ErrorMessage = "Obrigatório informar a preferência!")]
        public Pref Preferencia { get; set; }
    }

    public enum Pref
    {
        DestinosExoticos,
        AventuraArLivre,
        PatrimonioCultural,
        RelaxamentoResorts,
        TurismoGastronomico
    }
}
