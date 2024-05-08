using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encantos_do_Brasil.Models
{
    [Table("Favoritos")]
    public class Favorito
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Escolha uma Cidade")]
        public int IdCidade { get; set; }

        [ForeignKey("IdCidade")]
        public Cidade Cidade { get; set; }

        [Display(Name = "Hotel")]
        [Required(ErrorMessage = "Escolha um Hotel")]
        public int IdHotel { get; set; }

        [ForeignKey("IdHotel")]
        public Hotel Hotel { get; set; }

        [Display(Name ="Ponto Turístico")]
        [Required(ErrorMessage ="Escolha um ponto turístico")]
        public int IdPontoTuristico { get; set; }

        [ForeignKey("IdPontoTuristico")]
        public PontoTuristico PontoTuristico { get; set; }

    }
}
