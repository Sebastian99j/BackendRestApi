namespace BackendRestApi.Models
{
    public class TrainingSeriesDto
    {
        public int Id { get; set; }
        public string TrainingType { get; set; }
        public double Weight { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public int Rpe { get; set; }
        public DateTime DateTime { get; set; }
        public int BreaksInSeconds { get; set; }
        public bool Trained { get; set; }
        public int? UserId { get; set; } = null;
    }
}
