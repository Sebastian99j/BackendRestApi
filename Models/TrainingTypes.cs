using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRestApi.Models;

[Table("TrainingTypes")]
public partial class TrainingTypes
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TrainingSeries> TrainingSeries { get; set; } = new List<TrainingSeries>();
}
