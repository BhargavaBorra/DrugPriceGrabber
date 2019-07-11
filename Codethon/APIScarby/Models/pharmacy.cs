using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace APIScarby.Models
{
    [Table("PriceComp")]
    public class pharmacy
    {
        [Key]
        [Column("Id")]
        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public string PharmaName { get; set; }
        public string Price
        {
            get; set;
        }
        [Column("Websiteurl")]
        public string pharmaUrl { get; set; }
        [Column("Zipcode")]
        public string pharmaPincode { get; set; }
    }
}