using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType;

public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters.");

        RuleFor(r => r.DefaultDays)
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100.")
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1.");

        RuleFor(r => r)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("Leave Type already exist");
        _leaveTypeRepository = leaveTypeRepository;
    }

    private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
    {
        return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}
