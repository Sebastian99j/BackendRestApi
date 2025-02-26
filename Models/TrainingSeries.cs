using System;
using System.Collections.Generic;

namespace BackendRestApi.Models;

public partial class TrainingSeries
{
    public int Id { get; set; }

    public int? TrainingTypeId { get; set; }

    public int? UserId { get; set; }

    public double? Weight { get; set; }

    public int? Reps { get; set; }

    public int? Sets { get; set; }

    public int? RPE { get; set; }

    public DateOnly? DateTime { get; set; }

    public int? BreaksInSeconds { get; set; }

    public bool? Trained { get; set; }

    public virtual TrainingType? TrainingType { get; set; }

    public virtual User? User { get; set; }
}
