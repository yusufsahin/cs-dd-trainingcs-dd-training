
namespace Storium.Domain.Shared
{
    public sealed record Name
    {
        public string Value { get; init; }

        public Name(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("İsim alanı boş geçilemez");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException("İsim alanı 3 karakterden küçük olamaz");
            }

            if(value.Length > 50)
            {
                throw new ArgumentException("İsim alanı 50 karakterden büyük olamaz");
            }

            Value = value;
        }
    }
}
