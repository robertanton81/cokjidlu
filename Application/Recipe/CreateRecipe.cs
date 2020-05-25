namespace Application.Recipes
{
    using DataAccess;
    using Domain;
    using FluentValidation;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateRecipe
    {
        public class Command: IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public List<RecipeIngredients> RecipeIngredients { get; set; }
            public string Instructions { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            // FluentValidationAspNetCore
            public CommandValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Id).NotEmpty();
            }
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
                
                // TODO: add recipe ingredients validation
                
                _ctx.Recipes.Add(recipe);
                var res = await _ctx.SaveChangesAsync() > 0;
                if (res)
                {
                    return Unit.Value;
                } 
                else
                {
                    throw new Exception("Error saving changes");
                }
            }
        }
    }
}
