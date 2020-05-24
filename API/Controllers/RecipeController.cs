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

    public class RecipeController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<List<RecipeDto>>> GetList(CancellationToken ct)
        {
            return await Mediator.Send(new RecipesList.Query(), ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> GetDetail(Guid id)
        {
            return await Mediator.Send(new RecipeDetail.Query { RecipeId = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateRecipe(CreateRecipe.Command cmd)
        {
            return await Mediator.Send(cmd);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> EditRecipe(Guid id, RecipeEdit.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }
    }
}