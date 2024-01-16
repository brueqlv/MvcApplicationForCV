namespace MvcApplicationForCV.Models
{
    public class CV
    {
        public int Id { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public List<Education> Educations { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; }
        public List<LanguageSkills> LanguageSkills { get; set; }
    }
}
