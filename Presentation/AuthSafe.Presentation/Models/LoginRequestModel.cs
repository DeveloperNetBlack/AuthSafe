namespace AuthSafe.Presentation.Models
{
    public class LoginRequestModel
    {
        public string CompanyDocumentNumber { get; set; } = null!;

        public string UserName { get; set; } = null!;
        
        public string Password { get; set; } = null!;
    }
}
