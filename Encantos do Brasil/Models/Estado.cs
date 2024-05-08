using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encantos_do_Brasil.Models
{
    [Table("Estados")]
    public class Estado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Insira o nome do estado!")]
        public string Nome { get; set; }

        [Display(Name ="Região")]
        [Required(ErrorMessage ="Escolha a região!")]
        public int IdRegiao { get; set; }

        [ForeignKey("IdRegiao")]
        public RegiaoPais Regiao { get; set; }

        [Display(Name = "Preferência")]
        [Required(ErrorMessage = "Obrigatório informar a preferência!")]
        public Preferencia Preferencia { get; set; }

        public ICollection<Cidade> Cidades { get; set; }
    }
}
