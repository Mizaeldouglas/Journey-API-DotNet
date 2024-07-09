using Journey.Communication.Requests;
using Journey.Exception.ExceptionsBase;

namespace Journey.Application.UseCases.Trips.Register;

public class RegisterTripUseCase
{
    public void Excute(RequestRegisterTripJson request)
    {
        Validade(request);
    }

    private void Validade(RequestRegisterTripJson request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new JourneyException("Nome não pode Ser Vazio");
        }

        if (request.StartDate.Date < DateTime.UtcNow.Date)
        {
            throw new JourneyException("A viagem não pode ser registrada para uma data passada");
        }
        
        if (request.EndDate < request.StartDate)
        {
            throw new JourneyException("A viagem deve terminar apos a data de inicio");
        }
        
    }
}