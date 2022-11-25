using System.ComponentModel.DataAnnotations;

namespace SAMCLIENTAPI.models
{
    public class user
    {
        [Key]
        public int Id { get; set; }
        public string fullName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string token { get; set; }   
        public string refreshToken { get; set; }
    
    }
}
