using System.ComponentModel.DataAnnotations;

namespace MobilityEye.Models
{
    public class FormControlOption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OptionLabel { get; set; }

        public FormControl FormControl { get; set; }

        [Required]
        public int FormControlId { get; set; }

    }
}
