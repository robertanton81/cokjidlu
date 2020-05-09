using DataAccess;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Recipes
{
    public class RecipesList
    {
        public class Query: IRequest<List<Recipe>> { }
        public class Handler: IRequestHandler<Query, List<Recipe>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }
            public async Task<List<Recipe>> Handle(Query request, CancellationToken cancelationToken)
            {
                var recipes = await _context.Recipes.ToListAsync();
                return recipes;
            }
        }
    }
}
