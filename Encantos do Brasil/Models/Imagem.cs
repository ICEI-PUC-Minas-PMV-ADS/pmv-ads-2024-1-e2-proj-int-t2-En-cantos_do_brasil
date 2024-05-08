using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Encantos_do_Brasil.Models
{
    [Table("Imagens")]
    public class Imagem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Dados { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string TipoConteudo { get; set; }
    }
}
