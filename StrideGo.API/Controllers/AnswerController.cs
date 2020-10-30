using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrideGo.Business.Answers.Commands.CreateAnswer;
using StrideGo.Business.Answers.Commands.DeleteAnswer;
using StrideGo.Business.Answers.Commands.UpdateAnswer;
using StrideGo.Business.Answers.Queries.GetAnswerDetail;
using StrideGo.Business.Answers.Queries.GetAnswerList;

namespace StrideGo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<AnswerController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int? questionId)
        {
            var answerList = await _mediator.Send(new GetAnswerListQuery { QuestionId = questionId });
            return Ok(answerList);
        }

        // GET api/<AnswerController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var answer = await _mediator.Send(new GetAnswerDetailQuery { Id = id });
            return Ok(answer);

        }

        // POST api/<AnswerController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Create([FromBody] CreateAnswerCommand command)
        {
            var answerId = await _mediator.Send(command);
            return Ok(answerId);
        }

        // PUT api/<AnswerController>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateAnswerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<AnswerController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAnswerCommand { Id = id });
            return NoContent();
        }
    }
}
