using FluentValidation;
using SPTest.UserReceiverService.Api.User.Queries.GetUsers;

namespace SPTest.UserProcessingService.Api.User.Commands.Create
{
    public class GetUsersValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersValidator()
        {
            RuleFor(x => x.OrgId).NotEmpty();
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(1);
        }
    }
}
