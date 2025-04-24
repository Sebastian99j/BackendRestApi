using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRestApi.Models;

[Table("Users")]
public partial class Users
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string? AiIdentifier { get; set; }
    public string? PasswordHash { get; set; }

    public virtual ICollection<TrainingSeries> TrainingSeries { get; set; } = new List<TrainingSeries>();
}
