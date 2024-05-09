using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Encantos_do_Brasil.Models
{
    [Table("ImagensCidades")]
    public class ImagemCidade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Dados { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string TipoConteudo { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Escolha uma cidade!")]
        public int IdCidade { get; set; }

        [ForeignKey("IdCidade")]
        public Cidade Cidade { get; set; }
    }
}
