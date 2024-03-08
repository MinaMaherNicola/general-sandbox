using DesignPatterns.ConsoleApp.StructuralPatterns.AdapterPattern.LegacyData;
using DesignPatterns.ConsoleApp.StructuralPatterns.AdapterPattern.NewData;

namespace DesignPatterns.ConsoleApp.StructuralPatterns.AdapterPattern.Adapter
{
    public class NewUserAdapter : NewUser
    {
        public NewUserAdapter(LegacyUser legacyUser)
        {
            Id = legacyUser.Id;
            Name = $"{legacyUser.FirstName} {legacyUser.LastName}";
        }
    }
}
