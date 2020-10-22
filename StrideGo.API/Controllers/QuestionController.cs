using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StrideGo.Business.Questions.Queries.GetQuestionList;
using StrideGo.Business.Questions.Queries.GetQuestionDetail;
using StrideGo.Business.Questions.Commands.CreateQuestion;
using StrideGo.Business.Questions.Commands.UpdateQuestion;
using Microsoft.AspNetCore.Http;
using StrideGo.Business.Questions.Commands.DeleteQuestion;

namespace StrideGo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<QuestionController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var questionList = await _mediator.Send(new GetQuestionListQuery());
            return Ok(questionList);
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var question = await _mediator.Send(new GetQuestionDetailQuery { Id = id });
            return Ok(question);
        }

        // POST api/<QuestionController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Create([FromBody] CreateQuestionCommand command)
        {
            var questionId = await _mediator.Send(command);
            return Ok(questionId);
        }

        // PUT api/<QuestionController>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateQuestionCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteQuestionCommand { Id = id });
            return NoContent();
        }
    }
}
