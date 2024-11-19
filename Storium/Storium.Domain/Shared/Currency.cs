namespace Storium.Domain.Shared
{
    public sealed record Currency
    {
        internal static readonly Currency None = new("");

        public static readonly Currency Usd = new("Usd");
        public static readonly Currency Eur = new("Eur");
        public static readonly Currency Gbp = new("Gbp");
        public static readonly Currency TRY = new("TRY");
        private string Code { get; init; }

        public Currency(string code)
        {
            Code = code;
        }

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(x => x.Code == code) ?? 
                throw new ArgumentException("Geçerli bir para birimi girin!"); ;
        }

        public static readonly IReadOnlyCollection<Currency> All = new[] { Usd,Eur,Gbp, TRY };

    }
}
