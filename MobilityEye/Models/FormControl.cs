using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MobilityEye.Models
{
    public class FormControl
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Lable { get; set; }

        [Required]
        public string Type { get; set; }

        public IList<FormControlOption> FormControlOptions { get; set; }

        public Models.Form Form { get; set; }
        
        [Required]
        public int FormId { get; set; }

        public FormControl()
        {
            FormControlOptions = new List<FormControlOption>();
            ;
        }
    }
}
