namespace DevJobs.API.Controllers
{
    using DevJobs.API.Entities;
    using DevJobs.API.Models;
    using DevJobs.API.Persistence;
    using DevJobs.API.Persistence.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        private readonly IJobVacancyRepository _repository;

        public JobVacanciesController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {   
            var jobVacancies = _repository.Getall();
            return Ok(jobVacancies);    
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobVacancy = _repository.GetById(id);

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

           _repository.Add(jobVacancy);

            return CreatedAtAction("GetById", new { id = jobVacancy }, jobVacancy);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
            var jobVacancy = _repository.GetById(id);

            if(jobVacancy == null)
            return NotFound();

            jobVacancy.Update(model.title, model.description);
            _repository.Update(jobVacancy);
            
            return NoContent();
        }
    }
}