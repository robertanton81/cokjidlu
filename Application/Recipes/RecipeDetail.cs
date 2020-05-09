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
    public class RecipeDetail
    {
        public class Query : IRequest<Recipe>
        {
            public Guid RecipeId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Recipe>
        {
            private readonly DataContext _ctx;

            public Handler(DataContext ctx)
            {
                _ctx = ctx;
            }
            public async Task<Recipe> Handle(Query request, CancellationToken cancellationToken)
            {
                var recipe = await _ctx.Recipes.FindAsync(request.RecipeId);
                return recipe;
            }
        }
    }
}
