
using OionArcMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace OionArcMVC.ViewModel
{
    public class EvaluationViewModel
    {
        public string Solution { get; set; }
        public IEnumerable<Evaluation> Evaluations { get; set; }
        [Required(ErrorMessage = " please check evaluation")]
        public string SelectedGrade { get; set; }
        public string Comment { get; set; }
        public string StudentId { get; set; }
        public int AssginmentId { get; set; }
        public int? SessionId { get; set; }
    }
}
