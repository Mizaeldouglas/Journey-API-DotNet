using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Trips.Register;

public class RegisterTripUseCase
{


    public ResponseShortTripJson Excute(RequestRegisterTripJson request)
    {
        var dbContext = new JourneyDbContext();
        
        Validade(request);
        var tripEntity = new Trip
        {
          Name  = request.Name,
          StartDate = request.StartDate,
          EndDate = request.EndDate
        };
        
        dbContext.Trips.Add(tripEntity);
        dbContext.SaveChanges();

        return new ResponseShortTripJson
        {
            EndDate = tripEntity.EndDate,
            StartDate = tripEntity.StartDate,
            Name = tripEntity.Name,
            Id = tripEntity.Id
        };
    }

    private void Validade(RequestRegisterTripJson request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new JourneyException(ResourceErrorMessages.NAME_EMPTY);
        }

        if (request.StartDate.Date < DateTime.UtcNow.Date)
        {
            throw new JourneyException(ResourceErrorMessages.DATE_TRIP_MUST_BE_LATER_THAN_TODAY);
        }
        
        if (request.EndDate < request.StartDate)
        {
            throw new JourneyException(ResourceErrorMessages.END_DATE_TRIP_MUST_BE_LATER_START_DATE);
        }
        
    }
}