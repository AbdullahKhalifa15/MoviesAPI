
using System.ComponentModel.DataAnnotations;

namespace Hope.Web.ViewModels
{
    public class AwarenessViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2,ErrorMessage ="The Title must be more Than 2 Characters")]
        public string Title { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The Category must be more Than 2 Characters")]
        public string Category { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The Author Name must be more Than 2 Characters")]
        public string Author { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "The Artical Body must be more Than 10 Characters")]
        public string Data { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        public string VideoLink { get; set; }

    }
}
