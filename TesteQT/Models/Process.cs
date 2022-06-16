using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteQT.Models
{
    [Table("Process")]
    public class Process
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "ProcessCode")]
        [Column("ProcessCode")]
        [Required(ErrorMessage = "O código do processo é obrigatorio.")]
        public string ?ProcessCode { get; set; }
    }
}
