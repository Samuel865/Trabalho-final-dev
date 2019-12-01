using System.Collections.Generic;

namespace PetShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Pet> Pets { get; set; } = new List<Pet>();

        public void AddPet(Pet pet)
        {
            Pets.Add(pet);
        }
        public void RemovePet(Pet pet)
        {
            Pets.Remove(pet);
        }             
    }
}