﻿using System;
using System.Collections.Generic;

namespace BloodDonation_SWD.Models;

public partial class BloodRequest
{
    public int BloodRequestId { get; set; }

    public int? UserId { get; set; }

    public int? BloodTypeId { get; set; }

    public int? BloodComponentId { get; set; }

    public bool? IsEmergency { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Location { get; set; }

    public int? Quantity { get; set; }

    public bool? Fulfilled { get; set; }

    public string? FulfilledSource { get; set; }

    public decimal? HeightCm { get; set; }

    public decimal? WeightKg { get; set; }

    public string? MedicalHistory { get; set; }

    public string? PatientCondition { get; set; }

    public string? ReasonForRequest { get; set; }

    public string? UrgencyLevel { get; set; }

    public virtual BloodComponent? BloodComponent { get; set; }

    public virtual ICollection<BloodRequestInventory> BloodRequestInventories { get; set; } = new List<BloodRequestInventory>();

    public virtual BloodType? BloodType { get; set; }

    public virtual ICollection<RequestMatch> RequestMatches { get; set; } = new List<RequestMatch>();

    public virtual User? User { get; set; }
}
