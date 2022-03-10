using DevJobs.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevJobs.API.Persistence.Repositories
{
    public class JobVacancyRepository : IJobVacancyRepository
    {
        private DevJobsContext _context;

        public JobVacancyRepository(DevJobsContext context)
        {
            _context = context;
        }

        List<JobVacancy> IJobVacancyRepository.Getall()
        {
            return _context.JobVacancies.ToList();
        }

        JobVacancy IJobVacancyRepository.GetById(int id)
        {
            return _context.JobVacancies
            .Include(jv => jv.Applications)
            .SingleOrDefault(jv => jv.Id == id);
        }

        void IJobVacancyRepository.Add(JobVacancy jobVacancy)
        {
            _context.JobVacancies.Add(jobVacancy);
            _context.SaveChanges();
        }

        void IJobVacancyRepository.Update(JobVacancy jobVacancy)
        {
            _context.JobVacancies.Update(jobVacancy);
            _context.SaveChanges();
        }

        void IJobVacancyRepository.AddApplication(JobApplication jobApplication)
        {
            _context.JobApplications.Add(jobApplication);
            _context.SaveChanges();
        }
    }
}