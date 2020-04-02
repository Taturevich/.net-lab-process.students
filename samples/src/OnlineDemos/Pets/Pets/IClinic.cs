using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pets
{
    public interface IClinic
    {
        Pet Heal(Pet pet);
    }

    public class Clinic : IClinic
    {
        public Pet Heal(Pet pet) => new Pet
        {
            Type = "bird",
            Name = "YOU ARE NEW NOT"
        };
    }
}