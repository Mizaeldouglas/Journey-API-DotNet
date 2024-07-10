using Journey.Application.UseCases.Trips.Delete;
using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
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
    [SwaggerOperation(Summary = "Cadastra uma nova viagem",
        Description =
            "Este endpoint permite ao usuário cadastrar uma nova viagem, fornecendo detalhes como nome, data de início e data de término.")]
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
    {
        var useCase = new RegisterTripUseCase();
        var response = useCase.Execute(request);
        return Created(string.Empty, response);
    }

    /// <summary>
    /// Retorna todas as viagens cadastradas.
    /// </summary>
    [SwaggerOperation(Summary = "Retorna todas as viagens cadastradas",
        Description = "Este endpoint retorna uma lista de todas as viagens cadastradas no sistema.")]
    [HttpGet]
    [ProducesResponseType(typeof(ResponseTripsJson), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllTripsUseCase();
        var response = useCase.Excute();
        return Ok(response);
    }


    /// <summary>
    /// Retorna uma viagem específica.
    /// </summary>
    [SwaggerOperation(Summary = "Retorna uma viagem específica",
        Description = "Este endpoint retorna uma viagem específica, com base no ID fornecido.")]
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTripsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var useCase = new GetTripByIdUseCase();
        var response = useCase.Execute(id);
        return Ok(response);
    }

    /// <summary>
    /// Deleta uma viagem específica.
    /// </summary>
    [SwaggerOperation(Summary = "Deleta uma viagem específica",
        Description = "Este endpoint deleta uma viagem específica, com base no ID fornecido.")]
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult DeleteActivity([FromRoute] Guid id)
    {
        var useCase = new DeleteTripByIdUseCase();
        useCase.Execute(id);
        return NoContent();
    }
    
}