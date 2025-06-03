using System.ComponentModel.DataAnnotations;

namespace OionArcMVC.ViewModel
{
    public class AssginmentViewModel
    {
       public int Id { get; set; }
        [Required(ErrorMessage ="please enter the deadline.")]
        public DateTime DeadLine { get; set; }
        [Required(ErrorMessage ="please enter your material.")]
        public string Material { get; set; }
        [Required(ErrorMessage ="please enter the question.")]
        public string Question { get; set; }
        public string Description { get; set; }
        public int? SessionId { get; set; }
        public DateTime Published { get; set; } = DateTime.Now;
    }
}
