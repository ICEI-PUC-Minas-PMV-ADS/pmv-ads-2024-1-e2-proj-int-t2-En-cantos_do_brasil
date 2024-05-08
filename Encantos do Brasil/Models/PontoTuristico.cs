using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encantos_do_Brasil.Models
{
    [Table("PontosTuristicos")]
    public class PontoTuristico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o nome do Hotel!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o custo da diária do Hotel!")]
        public float Custo { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Escolha uma cidade!")]
        public int IdCidade { get; set; }

        [ForeignKey("IdCidade")]
        public Cidade Cidade { get; set; }

        public ICollection<Favorito> Favoritos { get; set; }
    }
}
