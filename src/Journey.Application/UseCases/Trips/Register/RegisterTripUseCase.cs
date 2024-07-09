using Journey.Communication.Requests;

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
            throw new ArgumentException("Nome não pode Ser Vazio");
        }

        if (request.StartDate.Date < DateTime.UtcNow.Date)
        {
            throw new ArgumentException("A viagem não pode ser registrada para uma data passada");
        }
        
        if (request.EndDate < request.StartDate)
        {
            throw new ArgumentException("A viagem deve terminar apos a data de inicio");
        }
        
    }
}