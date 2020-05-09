using DataAccess;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Recipes
{
    public class CreateRecipe
    {
        public class Command: IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public List<RecipeIngredients> RecipeIngredients { get; set; }
            public string Instructions { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _ctx;

            public Handler(DataContext ctx)
            {
                _ctx = ctx;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var recipe = new Recipe
                {
                    Id = request.Id,
                    Instructions = request.Instructions,
                    Title = request.Title
                };

                _ctx.Recipes.Add(recipe);
                var res = await _ctx.SaveChangesAsync() > 0;
                if (res)
                {
                    return Unit.Value;
                } 
                else
                {
                    throw new Exception("Error saving changs");
                }
            }
        }
    }
}
