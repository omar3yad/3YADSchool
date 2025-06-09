using System.ComponentModel.DataAnnotations;

namespace ITISchool.ViewModel
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool rememberMe { get; set; }
    }
}
