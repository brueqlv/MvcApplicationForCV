namespace MvcApplicationForCV.Models
{
    public class DataBaseFiller
    {
        public static void FillData(IServiceProvider serviceProvider)
        {
            using(var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MvcApplicationForCvDbContext>();

                    SeedDummyData(dbContext); //Should change to filling actual data
            }
        }

        private static void SeedDummyData(MvcApplicationForCvDbContext dbContext)
        {
            Address address1 = new Address
            {
                Country = "Pekina",
                City = "Voul",
                Street = "Pala",
                StreetNumber = 12,
                PostalCode = "CZ-4713"
            };

            Address address2 = new Address
            {
                Country = "Pekina",
                City = "Sala",
                Street = "Tia",
                StreetNumber = 1,
                PostalCode = "Zc-4713"
            };

            Education education1 = new Education
            {
                Name = "Krūmi",
                Course = "Ogas",
                EducationLevel = "Bachelor",
                EducationStatuss = Enum.EducationStatuss.Compleated,
                StartDate = new DateTime(2015, 09, 01),
                EndDate = new DateTime(2018,05,29)
            };

            Education education2 = new Education
            {
                Name = "Upe",
                Course = "Peldēt",
                EducationLevel = "Bachelor",
                EducationStatuss = Enum.EducationStatuss.InProgress,
                StartDate = new DateTime(2017, 09, 01),
            };

            LanguageSkills languageskills1 = new LanguageSkills
            {
                Name = "Pakistan",
                Listening = Enum.LanguageSkills.B2,
                Reading = Enum.LanguageSkills.C1,
                Speaking = Enum.LanguageSkills.C2,
                Writing = Enum.LanguageSkills.B2
            };

            LanguageSkills languageskills2 = new LanguageSkills
            {
                Name = "Estonian",
                Listening = Enum.LanguageSkills.C2,
                Reading = Enum.LanguageSkills.C2,
                Speaking = Enum.LanguageSkills.C2,
                Writing = Enum.LanguageSkills.C2
            }; 
            
            PersonalInfo personalInfo = new PersonalInfo
            {
                FirstName = "Peter",
                LastName = "Parker",
                PhoneNumber = "123-456-7890",
                Email = "peter.parked@example.com",
                AddressList = new List<Address> { address1, address2 }
            };

            WorkExperience workExperience = new WorkExperience
            {
                CompanyName = "Universal Pictures",
                PositionTitle = "Gradener",
                PositionDescription = "Clean webs",
                WeeklyWorkLoad = 40,
                StartDate = new DateTime(2017, 01, 01),
                EndDate = new DateTime(2018, 02, 02),
            };

            var cv = new CV
            {
                PersonalInfo = personalInfo,
                Educations = new List<Education> { education1, education2 },
                WorkExperiences = new List<WorkExperience> { workExperience },
                LanguageSkills = new List<LanguageSkills> { languageskills1, languageskills2 }
            };

            dbContext.CVs.Add(cv);
            dbContext.SaveChanges();
        }
    }
}
