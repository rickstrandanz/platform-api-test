namespace platform_api.Controllers
{
    public class Version
    {
        public string ApplicationVersion { get; set; }        
        public string LastCommitSHA { get; set; }
        public string Description { get; set; }
    }
}