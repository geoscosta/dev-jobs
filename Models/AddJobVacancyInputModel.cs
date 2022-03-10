namespace DevJobs.API.Models
{
    public record AddJobVacancyInputModel(
        string title, 
        string description, 
        string company, 
        bool isRemote, 
        string salaryRange
    )
    {
    }
}