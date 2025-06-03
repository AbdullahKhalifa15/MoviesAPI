
using System.ComponentModel.DataAnnotations;

namespace OionArcMVC.ViewModel
{
    public class SolutionViewModel
    {
        [Required(ErrorMessage ="please enter your solution.")]
        [MinLength(10,ErrorMessage ="the solution must be more than 10 character.")]
        public string Solution { get; set; }
    }
}
