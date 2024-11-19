
namespace Storium.Domain.Users
{
    public sealed record Email
    {
        public string Value { get; init; }

        public Email(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Email alanı boş geçilemez");
            }

            if (value.Length < 6)
            {
                throw new ArgumentException("Email alanı 6 karakterden küçük olamaz!");
            }
            if (!value.Contains("@"))
            {
                throw new ArgumentException("Geçerli bir email adresi giriniz");
            }

            Value = value;
        }
    }
}
