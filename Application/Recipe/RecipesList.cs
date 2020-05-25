namespace Application.Recipes
{
    using AutoMapper;
    using DataAccess;
    using Domain;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class RecipesList
    {
        public class Query: IRequest<List<RecipeDto>> { }
        public class Handler: IRequestHandler<Query, List<RecipeDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }
            public async Task<List<RecipeDto>> Handle(Query request, CancellationToken cancelationToken)
            {
                var recipes = await _context.Recipes
                     // .Include(r => r.RecipeIngredients)
                     // .ThenInclude(i => i.Ingredient)
                    .ToListAsync();

                var listToReturn = _mapper.Map<List<Recipe>, List<RecipeDto>>(recipes);
                return listToReturn;
            }
        }
    }
}
