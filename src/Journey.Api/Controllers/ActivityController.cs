using Journey.Application.UseCases.Trips.Activities.Complete;
using Journey.Application.UseCases.Trips.Activities.Delete;
using Journey.Application.UseCases.Trips.Activities.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Journey.Api.Controllers
{
    [Route("v1/Trips")]
    [ApiController]
    [SwaggerTag("Endpoints de atividades")]
    public class ActivityController : ControllerBase
    {
        
        
        /// <summary>
        ///  Registra uma nova atividade para uma viagem específica. 
        /// </summary>
        /// <param name="tripId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Registra uma nova atividade para uma viagem específica",
            Description = "Este endpoint permite ao usuário registrar uma nova atividade para uma viagem específica, fornecendo detalhes como nome e data.")]
        [HttpPost]
        [Route("{tripId}/activity")]
        [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult RegisterActivity([FromRoute] Guid tripId, [FromBody] RequestRegisterActivityJson request)
        {
            var useCase = new RegisterActivityForTripUseCase();
            var response = useCase.Execute(tripId, request);
            return Created(string.Empty, response);
        }
    
        /// <summary>
        ///  Marca uma atividade como concluída.
        /// </summary>
        /// <param name="tripId"></param>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Marca uma atividade como concluída",
            Description = "Este endpoint permite ao usuário marcar uma atividade específica de uma viagem como concluída.")]
        [HttpPut]
        [Route("{tripId}/activity/{activityId}/complete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult CompleteActivity([FromRoute] Guid tripId, [FromRoute] Guid activityId)
        {
            var useCase = new CompleteActivityForTripUseCase();
            useCase.Execute(tripId, activityId);
            return NoContent();
        }
    
    
        /// <summary>
        /// Deleta uma atividade específica de uma viagem.
        /// </summary>
        /// <param name="tripId"></param>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Deleta uma atividade específica de uma viagem",
            Description = "Este endpoint permite ao usuário deletar uma atividade específica de uma viagem.")]
        [HttpDelete]
        [Route("{tripId}/activity/{activityId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult DeleteActivity([FromRoute] Guid tripId, [FromRoute] Guid activityId)
        {
            var useCase = new DeleteActivityForTripUseCase();
            useCase.Execute(tripId, activityId);
            return NoContent();
        }

    }
}
