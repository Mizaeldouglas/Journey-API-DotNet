using Journey.Communication.Responses;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Trips.GetAll;

public class GetAllTripsUseCase
{
    public ResponseTripsJson Excute()
    {
        var dbContext = new JourneyDbContext();
        
        var trips = dbContext.Trips.ToList();

        return new ResponseTripsJson
        {
            Trips = trips.Select(t => new ResponseShortTripJson
            {
                Id = t.Id,
                EndDate = t.EndDate,
                StartDate = t.StartDate,
                Name = t.Name
            }).ToList()
        };
    }
}