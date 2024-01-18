

using Microsoft.EntityFrameworkCore;

namespace MvcApplicationForCV.Models
{
    public class CvDataService
    {
        private readonly MvcApplicationForCvDbContext _dbContext;

        public CvDataService(MvcApplicationForCvDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CV> GetAllCVs()
        {
            return _dbContext.CVs
                .Include(cv => cv.PersonalInfo)
                .Include(cv => cv.Educations)
                .Include(cv => cv.WorkExperiences)
                .Include(cv => cv.LanguageSkills)
                .ToList();
        }

        public async Task<CV?> GetCVFromIdAsync(int id)
        {
            return await _dbContext.CVs
                .Include(cv => cv.PersonalInfo)
                    .ThenInclude(pi => pi.AddressList)
                .Include(cv => cv.Educations)
                .Include(cv => cv.WorkExperiences)
                .Include(cv => cv.LanguageSkills)
                .FirstOrDefaultAsync(cv => cv.Id == id);
        }

        public async Task EditCV(int cvId, CV updatedCV)
        {
            CV? existingCV = await _dbContext.CVs
                .Include(cv => cv.PersonalInfo)
                    .ThenInclude(pi => pi.AddressList)
                .Include(cv => cv.Educations)
                .Include(cv => cv.WorkExperiences)
                .Include(cv => cv.LanguageSkills)
                .FirstOrDefaultAsync(cv => cv.Id == cvId);

            if (existingCV != null)
            {
                existingCV.UpdateFrom(updatedCV);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteCV(int cvId)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {

                CV? cvToDelete = _dbContext.CVs
                    .Include(cv => cv.PersonalInfo)
                        .ThenInclude(pi => pi.AddressList)
                    .Include(cv => cv.Educations)
                    .Include(cv => cv.WorkExperiences)
                    .Include(cv => cv.LanguageSkills)
                    .FirstOrDefault(cv => cv.Id == cvId);

                if (cvToDelete != null)
                {
                    _dbContext.RemoveRange(cvToDelete.PersonalInfo.AddressList);
                    _dbContext.Remove(cvToDelete.PersonalInfo);
                    _dbContext.RemoveRange(cvToDelete.Educations);
                    _dbContext.RemoveRange(cvToDelete.WorkExperiences);
                    _dbContext.RemoveRange(cvToDelete.LanguageSkills);

                    _dbContext.CVs.Remove(cvToDelete);
                    _dbContext.SaveChanges();

                    transaction.Commit();
                }
            }
        }

        public void AddCV(CV cv)
        {
            _dbContext.Add(cv);
            _dbContext.SaveChanges();
        }
    }
}
