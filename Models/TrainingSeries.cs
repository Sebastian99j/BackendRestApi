using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRestApi.Models;

[Table("TrainingSeries")]
public partial class TrainingSeries
{
    public int Id { get; set; }

    public int? TrainingTypeId { get; set; }

    public int? UserId { get; set; }

    public double? Weight { get; set; }

    public int? Reps { get; set; }

    public int? Sets { get; set; }

    public int? RPE { get; set; }

    public DateTime? DateTime { get; set; }

    public int? BreaksInSeconds { get; set; }

    public bool? Trained { get; set; }

    public virtual TrainingTypes? TrainingType { get; set; }

    public virtual Users? User { get; set; }
}
