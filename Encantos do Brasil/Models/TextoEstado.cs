using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encantos_do_Brasil.Models
{
    [Table("TextosEstados")]
    public class TextoEstado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TituloTexto { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public TipoTexto TipoTexto { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Escolha um estado!")]
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }
    }
}
