namespace OionArcMVC.ViewModel
{
    public class AttendanceViewModel
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
        public string Email { get; set; }
        public int SessionId { get; set; }
        public bool IsAttendant { get; set; } = true;
        public DateTime CreatedAt { get; set; }

    }
}
