﻿using Heartbeat.Domain.Checks;
using Heartbeat.Domain.Verification;

namespace Heartbeat.Domain;

public class WebApp
{
    public required Guid Id { get; set; } = Guid.NewGuid();

    public required string Label { get; set; }

    public virtual ICollection<VerificationStatus> VerificationHistory { get; set; } = new List<VerificationStatus>();

    public virtual ICollection<Check> Checks { get; set; } = new List<Check>();
}