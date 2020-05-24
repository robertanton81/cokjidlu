namespace API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Recipes;
    using Domain;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading;

    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecipeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<RecipeDto>>> GetList(CancellationToken ct)
        {
            return await _mediator.Send(new RecipesList.Query(), ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> GetDetail(Guid id)
        {
            return await _mediator.Send(new RecipeDetail.Query { RecipeId = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateRecipe(CreateRecipe.Command cmd)
        {
            return await _mediator.Send(cmd);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> EditRecipe(Guid id, RecipeEdit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}