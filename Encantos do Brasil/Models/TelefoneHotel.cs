using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encantos_do_Brasil.Models
{
    [Table("Telefones")]
    public class TelefoneHotel
    {
        [Key]
        public int IdTelefone { get; set; }

        [Required(ErrorMessage ="Insira o telefone do hotel!")]
        public string Telefone { get; set; }

        [Display(Name ="Hotel")]
        [Required(ErrorMessage ="Escolha um hotel!")]
        public int IdHotel { get; set; }

        [ForeignKey("IdHotel")]
        public Hotel Hotel { get; set; }
    }
}
