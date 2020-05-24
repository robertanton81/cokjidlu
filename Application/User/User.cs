namespace Application.User
{
    using Application.Errors;
    using DataAccess;
    using Domain;
    using FluentValidation;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class User
    {
            public string UserName { get; set; }
            public string Token { get; set; }
            public string DisplayName { get; set; }
    }
}
