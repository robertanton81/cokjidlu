namespace Application.Recipes
{
    using Application.Errors;
    using DataAccess;
    using FluentValidation;
    using MediatR;
    using System;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;


    public class RecipeEdit
    {
        public class Command: IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Instructions { get; set; }
            // public List<RecipeIngredients> RecipeIngredients { get; set; }
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
                var recipe = await _ctx.Recipes.FindAsync(request.Id);

                if (recipe == null)
                {
                    throw new RestExceptions(HttpStatusCode.NotFound, "Recept neexistuje");
                }

                recipe.Title = request.Title ?? recipe.Title;
                recipe.Instructions = request.Instructions ?? recipe.Instructions;

                var success = await _ctx.SaveChangesAsync() > 0;
                if (success)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Problem saving data");
                }
            }
        }
    }
}
