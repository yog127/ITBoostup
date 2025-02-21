using ITBoostUp.BusinessLayer.IRepository;
using ITBoostUp.BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITBoostUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        IStateRepository _stateRepository;

        public StateController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        [HttpGet("list")]
        public IActionResult StateList()
        {
            var result = _stateRepository.List();
            if(result == null)
            {
                return BadRequest("Not foundList");
            }
            return Ok(result);
        }
        [HttpPost("create")]
        public IActionResult Create(State state)
        {
            var result = _stateRepository.Create(state);
            if(result == null)
            {
                return BadRequest("Not Created");
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _stateRepository.GetElementById(id);
            if(result == null)
            {
                return BadRequest("Not Found");
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost("update/{id}")]
        public IActionResult Update(State state)
        {
            var result = _stateRepository.Update(state);
            if (result == null)
            {
                return BadRequest("Not Updated");
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return BadRequest("Id Not Found");
            }
            _stateRepository.Delete(id);
            return Ok();
        }
        
    }
}
