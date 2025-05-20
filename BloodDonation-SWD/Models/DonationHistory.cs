using System;
using System.Collections.Generic;

namespace BloodDonation_SWD.Models;

public partial class DonationHistory
{
    public int DonationId { get; set; }

    public int? UserId { get; set; }

    public int? BloodTypeId { get; set; }

    public int? BloodComponentId { get; set; }

    public DateOnly? Date { get; set; }

    public int? VolumeMl { get; set; }

    public string? Status { get; set; }

    public virtual BloodComponent? BloodComponent { get; set; }

    public virtual BloodType? BloodType { get; set; }

    public virtual User? User { get; set; }
}
