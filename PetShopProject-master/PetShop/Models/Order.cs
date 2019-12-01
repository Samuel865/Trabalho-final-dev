using System;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

        //Entity Relation         
        public int PetId { get; set; }
        public Pet Pet { get; set; }   
    }
}