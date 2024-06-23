using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encantos_do_Brasil.Models
{
    [Table("Comentarios")]
    public class Comentario
    {
        [Key]

        public int Id { get; set; }

        [Required]

        public string Comentarioss { get; set; }

        [Required]

        public int IdCidade { get; set; }


        [ForeignKey("IdCidade")]

        public Cidade Cidade { get; set; }
        public string Texto { get; set; }
    }
}
