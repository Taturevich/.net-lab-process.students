using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Pets
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PetService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PetService.svc or PetService.svc.cs at the Solution Explorer and start debugging.
    public class PetService : IPetService
    {
        private readonly IClinic _clinic;

        public PetService(IClinic clinic)
        {
            _clinic = clinic;
        }

        public void DoWork()
        {
        }

        public async Task<List<Pet>> GetPets()
        {
            await Task.Delay(500).ConfigureAwait(false);
            var pets = new List<Pet>()
            {
                new Pet { Name = "Barsik", Type = "cat" },
                new Pet { Name = "Sharick", Type = "dog" },
            };
            var healed = pets.Select(_clinic.Heal).ToList();
            return healed;
        }
    }
}
