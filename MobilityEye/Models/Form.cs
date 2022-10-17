using System.ComponentModel.DataAnnotations;

namespace MobilityEye.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public List<FormControl> FormControls { get; set; }

        public Form()
        {
            FormControls = new List<FormControl>();
        }

    }
}
