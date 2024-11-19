
namespace Storium.Domain.Users
{
    public sealed record Password
    {

        public string Value { get; init; }

        public Password(string value)
        {
            if(value == null) throw new ArgumentNullException("Password alanı boş geçilemez");
            if (value.Length < 6)
            {
                throw new ArgumentException("Password alanı 6 karakterden küçük olamaz!");
            }
            Value = value;
        }
    }
}
