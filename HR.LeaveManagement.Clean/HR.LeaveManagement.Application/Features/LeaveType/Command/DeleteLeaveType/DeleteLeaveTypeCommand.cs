using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.DeleteLeaveType;

public record DeleteLeaveTypeCommand(int Id) : IRequest<Unit>;
