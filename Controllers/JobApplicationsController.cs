namespace DevJobs.API.Controllers
{
    using DevJobs.API.Entities;
    using DevJobs.API.Models;
    using DevJobs.API.Persistence;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly DevJobsContext _context;

        public JobApplicationsController(DevJobsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationsInputModel model)
        {
            var jobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);

            if(jobVacancy == null)
            return NotFound();

            var application = new JobApplication(
                model.applicantName,
                model.applicantEmail,
                id
            );

            _context.JobApplications.Add(application);
            _context.SaveChanges();

            return NoContent();
        }
    }
}