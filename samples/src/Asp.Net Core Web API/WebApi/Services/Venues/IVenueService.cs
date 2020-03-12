using System.Threading.Tasks;
using WebApi.DataAccess.Models;
using WebApi.Dto;
using WebApi.Services.Core;

namespace WebApi.Services.Venues
{
    public interface IVenueService
    {
        Task<OperationResult<VenueOperationStatus, Venue>> GetById(int id);

        Task<OperationResult<VenueOperationStatus, int>> Create(VenueModel model);

        Task<VenueOperationStatus> Update(int id, VenueModel model);

        Task<VenueOperationStatus> Delete(int id);
    }
}