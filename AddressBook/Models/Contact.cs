using System.ComponentModel.DataAnnotations;

namespace AddressBookWebAiWithEntityFrameWork.Model
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$")]
        public string Email { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 10)]
        public string Mobile { get; set; }
        [Required]
        public string Landline { get; set; }
        [Required]
        [RegularExpression(@"^((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)")]
        public string Website { get; set; }
        public string Address { get; set; }
    }
}
