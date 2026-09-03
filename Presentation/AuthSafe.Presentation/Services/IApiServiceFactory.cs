namespace AuthSafe.Presentation.Services
{
    public interface IApiServiceFactory
    {
        ApiService Create(string httpClientNamed);
    }
}
