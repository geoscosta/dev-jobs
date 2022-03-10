namespace DevJobs.API.Controllers
{
    using DevJobs.API.Entities;
    using DevJobs.API.Models;
    using DevJobs.API.Persistence;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        private readonly DevJobsContext _context;

        public JobVacanciesController(DevJobsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {   
            var jobVacancies = _context.JobVacancies;
            return Ok(jobVacancies);    
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobVacancy = _context.JobVacancies
            .Include(jv => jv.Applications)
            .SingleOrDefault(jv => jv.Id == id);

            if(jobVacancy == null)
            return NotFound();

            return Ok(jobVacancy);
        }

        [HttpPost]
        public IActionResult Post(AddJobVacancyInputModel model)
        {
            var jobVacancy = new JobVacancy(
                model.title,
                model.description,
                model.company,
                model.isRemote,
                model.salaryRange
            );

            _context.JobVacancies.Add(jobVacancy);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = jobVacancy }, jobVacancy);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
            var jobVacancy = _context.JobVacancies
            .SingleOrDefault(jv => jv.Id == id);

            if(jobVacancy == null)
            return NotFound();

            jobVacancy.Update(model.title, model.description);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}