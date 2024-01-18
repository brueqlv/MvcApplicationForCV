namespace MvcApplicationForCV.Models
{
    public class WorkExperience
    {
        public int WorkExperienceId { get; set; }
        public string CompanyName { get; set; }
        public string PositionTitle { get; set; }
        public string PositionDescription { get; set; }
        public int WeeklyWorkLoad {  get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsStillWorking { get; set; } = false;
    }
}
