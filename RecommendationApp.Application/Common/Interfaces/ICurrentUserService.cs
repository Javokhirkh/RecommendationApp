namespace RecommendationApp.Application.Common;

public interface ICurrentUserService
{
    CurrentUser GetCurrentUser();

    public class CurrentUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string IPAddress { get; set; }
    }
}