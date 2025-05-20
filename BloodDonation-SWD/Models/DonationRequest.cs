﻿using System;
using System.Collections.Generic;

namespace BloodDonation_SWD.Models;

public partial class DonationRequest
{
    public int DonateRequestId { get; set; }

    public int? UserId { get; set; }

    public int? BloodTypeId { get; set; }

    public int? BloodComponentId { get; set; }

    public DateOnly? PreferredDate { get; set; }

    public string? Status { get; set; }

    public string? Location { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? Quantity { get; set; }

    public string? Note { get; set; }

    public decimal? HeightCm { get; set; }

    public decimal? WeightKg { get; set; }

    public string? MedicalHistory { get; set; }

    public string? GeneralHealthStatus { get; set; }

    public decimal? HemoglobinLevel { get; set; }

    public DateOnly? LastDonationDate { get; set; }

    public string? BloodPressure { get; set; }

    public int? PulseRate { get; set; }

    public virtual BloodComponent? BloodComponent { get; set; }

    public virtual BloodType? BloodType { get; set; }

    public virtual ICollection<RequestMatch> RequestMatches { get; set; } = new List<RequestMatch>();

    public virtual User? User { get; set; }
}
