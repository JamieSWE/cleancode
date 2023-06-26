using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.UpdateLeaveType;

public class UpdateLeaveTypeCommand : IRequest<Unit>
{
    public string Name { get; set; } = String.Empty;
    public int DefaultDays { get; set; }
}
