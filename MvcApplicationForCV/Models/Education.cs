namespace MvcApplicationForCV.Models
{
    public class Education
    {
        public int EducationId { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string EducationLevel { get; set; }
        public Enum.EducationStatuss EducationStatuss { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
