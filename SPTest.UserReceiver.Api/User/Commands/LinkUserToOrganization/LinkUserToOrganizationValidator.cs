using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTest.UserProcessingService.Api.User.Commands.Create
{
    public class LinkUserToOrganizationValidator : AbstractValidator<LinkUserToOrganizationCommand>
    {
        public LinkUserToOrganizationValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.OrganizationId).NotEmpty();

        }
    }
}
