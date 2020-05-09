using DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Recipes
{
    public class RecipeEdit
    {
        public class Command: IRequest
        {

        }

        public class Hanler: IRequestHandler<Command>
        {
            private readonly DataContext _ctx;

            public Hanler(DataContext ctx)
            {
                _ctx = ctx;
            }

            public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
