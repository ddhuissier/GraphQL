using GraphQL.API.Models;

namespace GraphQL.API.Data
{
    public class Query
    {
        // public IQueryable<User> GetUsers() => new List<User>().AsQueryable();
        public static User GetUser() => new User() { Id = 1, FirstName = "John", LastName="Doe" };
        //public static string Hero() => "Luke Skywalker";
    }
}
