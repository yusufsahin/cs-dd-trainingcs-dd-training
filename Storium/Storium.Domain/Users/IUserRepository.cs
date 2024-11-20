namespace Storium.Domain.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<User> CreateAsync(string name, string email, string password, string country, string city, string street, string postalCode, string fullAddress, CancellationToken cancellationToken = default);
    }
}
