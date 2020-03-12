using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using WebApi.DataAccess;
using WebApi.DataAccess.Models;
using WebApi.Dto;
using WebApi.Services.Core;

namespace WebApi.Services.Venues
{
    public class VenueService : IVenueService
    {
        private readonly WebApiDbContext _dbContext;
        private readonly EntityNamePostfixSettings _settings;

        public VenueService(WebApiDbContext dbContext, IOptions<EntityNamePostfixSettings> options)
        {
            _dbContext = dbContext;
            _settings = options.Value;
        }

        public async Task<OperationResult<VenueOperationStatus, Venue>> GetById(int id)
        {
            var venue = await _dbContext.Venues.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (venue == null)
            {
                return new OperationResult<VenueOperationStatus, Venue>
                {
                    Status = VenueOperationStatus.DoesNotExists
                };
            }

            return new OperationResult<VenueOperationStatus, Venue>
            {
                Status = VenueOperationStatus.Success,
                Result = venue
            };
        }

        public async Task<OperationResult<VenueOperationStatus, int>> Create(VenueModel model)
        {
            var venue = new Venue
            {
                Name = model.Name + _settings.NamePostfix,
                City = model.City
            };

            _dbContext.Venues.Add(venue);
            await _dbContext.SaveChangesAsync();

            return new OperationResult<VenueOperationStatus, int>
            {
                Status = VenueOperationStatus.Success,
                Result = venue.Id
            };
        }

        public async Task<VenueOperationStatus> Update(int id, VenueModel model)
        {
            var venue = await _dbContext.Venues.FindAsync(id);
            if (venue == null)
            {
                return VenueOperationStatus.DoesNotExists;
            }

            venue.Name = model.Name + _settings.NamePostfix;
            venue.City = model.City;
            await _dbContext.SaveChangesAsync();

            return VenueOperationStatus.Success;
        }

        public async Task<VenueOperationStatus> Delete(int id)
        {
            var venue = await _dbContext.Venues.FindAsync(id);
            if (venue == null)
            {
                return VenueOperationStatus.DoesNotExists;
            }

            _dbContext.Remove(venue);
            await _dbContext.SaveChangesAsync();

            return VenueOperationStatus.Success;
        }
    }
}
