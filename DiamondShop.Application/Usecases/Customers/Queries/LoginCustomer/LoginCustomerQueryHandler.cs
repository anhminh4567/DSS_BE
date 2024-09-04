﻿using BeatvisionRemake.Application.Services.Interfaces;
using DiamondShop.Application.Commons.Responses;
using DiamondShop.Application.Services.Data;
using DiamondShop.Application.Services.Interfaces;
using DiamondShop.Domain.Repositories;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.Application.Usecases.Customers.Queries.LoginCustomer
{
    public record LoginCustomerQuery(string email, string password) : IRequest<Result<AuthenticationResultDto>>;
    internal class LoginCustomerQueryHandler : IRequestHandler<LoginCustomerQuery, Result<AuthenticationResultDto>>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginCustomerQueryHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result<AuthenticationResultDto>> Handle(LoginCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.Login(request.email,request.password,cancellationToken);
        }
    }
}
