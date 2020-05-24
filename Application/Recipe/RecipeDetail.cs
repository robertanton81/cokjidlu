namespace Application.Recipes
{
    using Application.Errors;
    using AutoMapper;
    using DataAccess;
    using Domain;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    public class RecipeDetail
    {
        public class Query : IRequest<RecipeDto>
        {
            public Guid RecipeId { get; set; }
        }

        public class Handler : IRequestHandler<Query, RecipeDto>
        {
            private readonly DataContext _ctx;
            private readonly IMapper _mapper;

            public Handler(DataContext ctx, IMapper mapper)
            {
                _ctx = ctx;
                _mapper = mapper;
            }
            public async Task<RecipeDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var recipe = await _ctx.Recipes
                     // .Include(r => r.RecipeIngredients)
                     // .ThenInclude(i => i.Ingredient)
                     // .SingleOrDefaultAsync(x => x.Id == request.RecipeId);
                     .FindAsync(request.RecipeId);

                if (recipe == null)
                {
                    throw new RestExceptions(HttpStatusCode.NotFound, new { recipe = "Not found" });
                }

                var recipeToReturn = _mapper.Map<Recipe, RecipeDto>(recipe);

                return recipeToReturn;
            }
        }
    }
}
