using System;
using System.Collections.Generic;

namespace BackendRestApi.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string? AiIdentifier { get; set; }
    public string? PasswordHash { get; set; }

    public virtual ICollection<TrainingSeries> TrainingSeries { get; set; } = new List<TrainingSeries>();
}
