using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteQT.Controllers;
using TesteQT.Date;

namespace TesteQT.Models

{
    [Table("Document")]
    public class Document
    {
        private readonly Context _context;
        public Document(Context context)
        {
            _context = context;
        }

        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Display(Name = "DocumentCode")]
        [Column("DocumentCode")]
        [Required(ErrorMessage = "O código do documento é obrigatorio.")]
        public int DocumentCode { get; set; }

        [Display(Name = "Title")]
        [Column("Title")]
        [Required(ErrorMessage = "O Titulo é obrigatorio.")]
        public string? Title { get; set; }

        [Display(Name = "Process")]
        [Column("Process")]
        [Required(ErrorMessage = "O processo é obrigatorio.")]
        public Process? Process { get; set; }

        [Display(Name = "Category")]
        [Column("Category")]
        [Required(ErrorMessage = "A categoria é obrigatorio.")]
        public string? Category { get; set; }

        [Display(Name = "Files")]
        [Column("Files")]
        [Required(ErrorMessage = "O arquivo é obrigatorio.")]
        public string? Files { get; set; }
    }
}
