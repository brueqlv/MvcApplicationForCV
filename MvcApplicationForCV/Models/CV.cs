namespace MvcApplicationForCV.Models
{
    public class CV
    {
        public int Id { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
        public virtual List<Education> Educations { get; set; }
        public virtual List<WorkExperience> WorkExperiences { get; set; }
        public virtual List<LanguageSkills> LanguageSkills { get; set; }

        public CV()
        {
            Educations = new List<Education>();
            WorkExperiences = new List<WorkExperience>();
            LanguageSkills = new List<LanguageSkills>();
        }

        public void UpdateFrom(CV updatedCV)
        {
            PersonalInfo = updatedCV.PersonalInfo;
            Educations = updatedCV.Educations;
            WorkExperiences = updatedCV.WorkExperiences;
            LanguageSkills = updatedCV.LanguageSkills;
        }
    }
}
