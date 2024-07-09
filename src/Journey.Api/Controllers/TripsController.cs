using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Journey.Api.Controllers;

[Route("v1/[controller]")]
[ApiController]
[SwaggerTag("Endpoints de viagens")]
public class TripsController : ControllerBase
{
    
    /// <summary>
    /// Cadastra uma nova viagem.
    /// </summary>
    [HttpPost]
    [SwaggerOperation(Summary = "Cadastra uma nova viagem", Description = "Este endpoint permite ao usuário cadastrar uma nova viagem, fornecendo detalhes como nome, data de início e data de término.")]
    public IActionResult Register([FromBody]RequestRegisterTripJson request)
    {
        try
        {
            var useCase = new RegisterTripUseCase();
            var response = useCase.Excute(request);

            return Created(string.Empty,response);
        }
        catch (JourneyException e)
        {
            return BadRequest(e.Message);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro desconhecido");
        }
    }

    /// <summary>
    /// Retorna todas as viagens cadastradas.
    /// </summary>
    [HttpGet]
    [SwaggerOperation(Summary = "Retorna todas as viagens cadastradas", Description = "Este endpoint retorna uma lista de todas as viagens cadastradas no sistema.")]
    public IActionResult GetAll()
    {
        var useCase = new GetAllTripsUseCase();
        var result = useCase.Excute();
        
        return Ok(result);
    }
    
    
    /// <summary>
    /// Retorna uma viagem específica.
    /// </summary>
    [HttpGet]
    [Route("{id}")]
    [SwaggerOperation(Summary = "Retorna uma viagem específica", Description = "Este endpoint retorna uma viagem específica, com base no ID fornecido.")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        try
        {
            var useCase = new GetTripByIdUseCase();
            var result = useCase.Excute(id);
            
            return Ok(result);
        }
        catch (JourneyException e)
        {
            return NotFound(e.Message);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro desconhecido");
        }
    }
    
}

















