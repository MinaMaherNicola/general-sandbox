namespace DesignPatterns.ConsoleApp.StructuralPatterns.AdapterPattern.LegacyData
{
    public class LegacyUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public static LegacyUser GetUser()
        {
            return new LegacyUser() { Id = 1, FirstName = "John", LastName = "Doe" };
        }
    }
}
