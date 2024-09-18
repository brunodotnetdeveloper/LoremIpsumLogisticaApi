namespace LoremIpsumLogistica.Application.ViewModels
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Type { get; set; } // Tipo de endereço: Comercial, Residencial, etc.
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; } 
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }

        public virtual ClientViewModel Client { get; set; }
    }
}
