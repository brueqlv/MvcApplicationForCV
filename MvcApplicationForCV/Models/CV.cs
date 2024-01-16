namespace MvcApplicationForCV.Models
{
    public class CV
    {
        public int Id { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public ICollection<Education> Educations { get; set; } = new List<Education>();
        public ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
        public ICollection<LanguageSkills> LanguageSkills { get; set; } = new List<LanguageSkills>();

        public void UpdateFrom(CV updatedCV)
        {
            PersonalInfo = updatedCV.PersonalInfo;
            Educations = updatedCV.Educations;
            WorkExperiences = updatedCV.WorkExperiences;
            LanguageSkills = updatedCV.LanguageSkills;
        }
    }
}
