using Journey.Communication.Responses;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Trips.GetById;

public class GetTripByIdUseCase
{
    public ResponseTripJson Excute(Guid id)
    {
        var dbContext = new JourneyDbContext();
        
        var trip = dbContext.Trips.FirstOrDefault(t => t.Id == id);
        
        if (trip == null)
        {
            throw new JourneyException("Viagem não encontrada");
        }
        
        return new ResponseTripJson
        {
            Id = trip.Id,
            EndDate = trip.EndDate,
            StartDate = trip.StartDate,
            Name = trip.Name
        };
        
    }
}