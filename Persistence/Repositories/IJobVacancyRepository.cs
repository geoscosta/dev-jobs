using DevJobs.API.Entities;

namespace DevJobs.API.Persistence.Repositories
{
    public interface IJobVacancyRepository
    {
        List<JobVacancy> Getall();
        JobVacancy GetById(int id);
        void Add(JobVacancy jobVacancy);
        void Update(JobVacancy jobVacancy);
        void AddApplication(JobApplication jobApplication);
    }
}