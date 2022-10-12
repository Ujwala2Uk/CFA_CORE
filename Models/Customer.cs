using System.ComponentModel.DataAnnotations;

namespace CFA_CORE.Models
{
    public class Customer
    {
        [Key]
        public int Cust_Id { get; set; }

        [Required(ErrorMessage ="Enter Your Name")]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)?$")]
        public string Cust_Name { get; set; }

        [Range(18,90, ErrorMessage ="Enter your age between 18 to 90")]
        public int Cust_Age { get; set; }
        public DateTime OrderdDate { get; set; }
        public DateTime Cust_DOB { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Cust_MobileNo { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Cust_Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Please set a password")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{4,12}$")]
        public string Cust_Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Confirm your Password")]
        [Compare("Cust_Password", ErrorMessage ="Password does not match")]
        public string Cust_ConfirmPassword { get; set; }

    }
}
