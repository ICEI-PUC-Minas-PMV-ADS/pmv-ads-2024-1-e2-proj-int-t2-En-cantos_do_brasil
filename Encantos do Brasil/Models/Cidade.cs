using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encantos_do_Brasil.Models
{
    [Table("Cidades")]
    public class Cidade
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Insira o nome da cidade!")]
        public string Nome { get; set; }

        [Display(Name ="Estado")]
        [Required(ErrorMessage ="Escolha o estado!")]
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }

        [Display(Name = "Preferência")]
        [Required(ErrorMessage = "Obrigatório informar a preferência!")]
        public Preferencia Preferencia { get; set; }

        public ICollection<Hotel> Hoteis { get; set; }

        public ICollection<PontoTuristico> PontosTuristicos { get; set; }

        public ICollection<Favorito> Favoritos { get; set; }

        public ICollection<ImagemCidade> ImagensCidades { get; set; }

        public ICollection<TextoCidade> TextosCidades { get; set; }
    }
}
