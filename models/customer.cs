using System.ComponentModel.DataAnnotations;

namespace SAMCLIENTAPI.models
{
    public class customer
    {
        [Key]
        public int Id { get; set; }
        public string  customerName { get; set; }
        public string customerCode { get; set; }
        public string ABN { get; set; }
        public string division { get; set; }
        public string  address { get; set; }
        public string contactNo { get; set; }
        public string city { get; set; }
    }
}
