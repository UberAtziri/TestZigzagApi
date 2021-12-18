using System.ComponentModel.DataAnnotations;

namespace TestZigzagApi.Models
{
    public class LoginRegisterRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}