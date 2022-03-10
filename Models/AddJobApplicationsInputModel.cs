namespace DevJobs.API.Models
{
    public record AddJobApplicationsInputModel(
        string applicantName, 
        string applicantEmail, 
        int idJob
    )
    {   
    }
}