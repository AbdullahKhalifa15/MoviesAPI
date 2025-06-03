using System.ComponentModel.DataAnnotations;

namespace CancerProject.Models
{
    public abstract class UserBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Full Name should be more than 1  character !")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = " User Name should be more than 1 character !")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^([a-zA-Z0-9@*#]{8,100})$")]

        //[RegularExpression("^([a-zA-Z0-9@*#]{8,100})$", ErrorMessage = "Password matching expression.Match all alphanumeric character " +
        //   "and predefined wild characters. Password must consists of at least 8 characters and not more than 100 characters.")]
        public string Password { get; set; }
        [Required]
        [RegularExpression("^01[0125][0-9]{8}$")]
        //[RegularExpression("^01[0125][0-9]{8}$", ErrorMessage = "Phone length is exactly 11\r\n\r\nPhone Prefix is with in allowed ones 010, 011, 012, 015\r\n")]
        //[Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        public string Gander { get; set; }
        


    }
}
