using System;
using System.Collections.Generic;

namespace BackendRestApi.Models;

public partial class TrainingType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TrainingSeries> TrainingSeries { get; set; } = new List<TrainingSeries>();
}
