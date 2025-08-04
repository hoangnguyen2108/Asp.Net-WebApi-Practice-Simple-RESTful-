using System.ComponentModel.DataAnnotations;

namespace PracticeWebApi.Model
{
    public class Product
    {
        [Key]
        public int Productid { get; set; }
        public string? Name { get; set; }
        public int? Price {  get; set; }
        public string? Category { get; set; }
    }
}
