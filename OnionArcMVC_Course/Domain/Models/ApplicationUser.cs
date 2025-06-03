
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{ 
    public partial class ApplicationUser : IdentityUser 
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(11)]
        public string Phone { get; set; }
        public bool InActive { get; set; } = false;
        public byte[] ProfilePicture { get; set; }
        public string ImageSrc
        {
            get
            {
                if (ProfilePicture != null)
                {
                    string base64String = Convert.ToBase64String(ProfilePicture, 0, ProfilePicture.Length);
                    return "data:image/jpg;base64," + base64String;
                }
                else
                {
                    return string.Empty;
                }
               
            }

        }
        public int? CourseId { get; set; }
        

        public ICollection<Attendance> Attendances { get; set; }
        public  Course Course { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; }
      

    }
}
