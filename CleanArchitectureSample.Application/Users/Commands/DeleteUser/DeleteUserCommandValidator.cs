using System;
using FluentValidation;

namespace CleanArchitectureSample.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
