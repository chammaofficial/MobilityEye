using System.ComponentModel.DataAnnotations;

namespace MobilityEye.ViewModels
{
    public class CreateFormViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string JsonFormContent { get; set; }


        public CreateFormViewModel()
        {
            Id = 0;
        }
    }
}
