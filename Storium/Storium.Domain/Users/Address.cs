namespace Storium.Domain.Users
{
    public record Address(
        string Country,
        string City,
        string Street, 
        string Fulladdress, 
        string PostalCode);
  
}
/*
       public string Country { get; set; }
       public string City { get; set; }
       public string Street { get; set; }
       public string FullAddress{ get; set; }
       public string PostalCode { get; set; }
       */