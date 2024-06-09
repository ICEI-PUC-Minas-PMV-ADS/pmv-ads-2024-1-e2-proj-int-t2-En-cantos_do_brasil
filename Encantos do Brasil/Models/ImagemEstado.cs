using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Encantos_do_Brasil.Models
{
    [Table("ImagensEstados")]
    public class ImagemEstado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Dados { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string TipoConteudo { get; set; }

        [Required]
        public TipoImagem TipoImagem { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Escolha um estado!")]
        [ForeignKey("Estado")]
        public int IdEstado { get; set; }

        public Estado Estado { get; set; }
    }
}
