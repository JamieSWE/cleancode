﻿using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType;

public class CreateLeaveTypeCommand : IRequest<int>
{
    public string Name { get; set; } = String.Empty;
    public int DefaultDays { get; set; }
}
