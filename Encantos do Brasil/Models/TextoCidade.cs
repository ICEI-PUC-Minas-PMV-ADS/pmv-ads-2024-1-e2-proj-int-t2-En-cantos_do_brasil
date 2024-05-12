using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encantos_do_Brasil.Models
{
    [Table("TextosCidades")]
    public class TextoCidade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TituloTexto { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public TipoTexto TipoTexto { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Escolha uma cidade!")]
        public int IdCidade { get; set; }

        [ForeignKey("IdCidade")]
        public Cidade Cidade { get; set; }
    }

    public enum TipoTexto
    {
        Texto1,
        Texto2,
        Texto3,
        Texto4,
        Texto5,
        Texto6,
        Texto7,
    }
}
