namespace DevJobs.API.Entities
{
    public class JobApplication
    {
        public JobApplication(string applicantName, string applicantEmail, int idJob)
        {
            ApplicantName = applicantName;
            ApplicantEmail = applicantEmail;
            IdJob = idJob;
        }

        public int Id { get; private set; }
        public string ApplicantName { get; private set; }
        public string ApplicantEmail { get; private set; }
        public int IdJob { get; private set; }
    }
}