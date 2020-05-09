using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Recipes;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application;
using System.Threading;

namespace API.Controllers
{
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
        public async Task<ActionResult<List<Recipe>>> GetList(CancellationToken ct)
        {
            return await _mediator.Send(new RecipesList.Query(), ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetDetail(Guid id)
        {
            return await _mediator.Send(new RecipeDetail.Query { RecipeId = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateRecipe(CreateRecipe.Command cmd)
        {
            return await _mediator.Send(cmd);
        }
    }
}