namespace DevJobs.API.Controllers
{
    using DevJobs.API.Entities;
    using DevJobs.API.Models;
    using DevJobs.API.Persistence;
    using DevJobs.API.Persistence.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobVacancyRepository _repository;

        public JobApplicationsController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationsInputModel model)
        {
            var jobVacancy = _repository.GetById(id);

            if(jobVacancy == null)
            return NotFound();

            var application = new JobApplication(
                model.applicantName,
                model.applicantEmail,
                id
            );

            _repository.AddApplication(application);

            return NoContent();
        }
    }
}