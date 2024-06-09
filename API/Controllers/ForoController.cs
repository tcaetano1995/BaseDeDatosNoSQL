using Cassandra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ISession = Cassandra.ISession;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForoController : ControllerBase
    {

        private readonly Logic _foroLogic;


        public ForoController(ISession session)
        {
            _foroLogic = new Logic(session);
        }
        [HttpGet("byId")]
        public IActionResult GetMessageById([FromQuery] Guid id)
        {
            try
            {
                var message = _foroLogic.GetMessageById(id);
                if (message == null)
                    return NotFound($"Message with ID {id} not found");

                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("byForo")]
        public IActionResult GetMessageByForo([FromQuery] Guid id, [FromQuery] int last)
        {
            try
            {
                var messages = _foroLogic.GetMessagesByForo(id, last);
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("byTopic")]
        public IActionResult  GetMessageByTopic([FromQuery] Guid id, [FromQuery] int last)
        {
            {
                try
                {
                    var messages = _foroLogic.GetMessagesByTopic(id, last);
                    return Ok(messages);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
