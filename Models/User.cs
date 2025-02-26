using System;
using System.Collections.Generic;

namespace BackendRestApi.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Ai_Identifier { get; set; }

    public virtual ICollection<TrainingSeries> TrainingSeries { get; set; } = new List<TrainingSeries>();
}
