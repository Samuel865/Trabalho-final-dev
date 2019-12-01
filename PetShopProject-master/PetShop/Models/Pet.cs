using System.Collections.Generic;

namespace PetShop.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int Age { get; set; }
        public string Specie { get; set; }
        public ICollection<Order> Orderes { get; set; } = new List<Order>();

        //Entity Relation
        public int UserId { get; set; }
        public User User { get; set; }   

        public void AddOrder( Order order)
        {
            Orderes.Add(order);
        }

        public void RemoveOrder(Order order)
        {
            Orderes.Remove(order);
        }
    }
}