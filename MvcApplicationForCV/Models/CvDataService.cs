﻿namespace MvcApplicationForCV.Models
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
            return _dbContext.CVs.ToList();
        }

        public void EditCV(int CVId, CV updatedCV)
        {
            CV existingCV = _dbContext.CVs.Find(CVId);

            if(existingCV != null)
            {
                existingCV.UpdateFrom(updatedCV);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteCV(int CVId)
        {
            CV cvToDelete = _dbContext.CVs.Find(CVId);

            if(cvToDelete != null)
            {
                _dbContext.CVs.Remove(cvToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}