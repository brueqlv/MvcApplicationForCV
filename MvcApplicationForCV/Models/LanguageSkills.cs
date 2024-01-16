namespace MvcApplicationForCV.Models
{
    public class LanguageSkills
    {
        public int LanguageSkillsId { get; set; }
        public string Name { get; set; }
        public Enum.LanguageSkills Listening {  get; set; }
        public Enum.LanguageSkills Reading { get; set; }
        public Enum.LanguageSkills Speaking { get; set; }
        public Enum.LanguageSkills Writing { get; set; }
    }
}
