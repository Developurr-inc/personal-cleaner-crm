using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Manager;

public class ManagerGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateManagers()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[]
            {
                ManagerFixture.CreateManager()
            };
    }
    
    
    public static IEnumerable<object[]> CreateInvalidManagerNames()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                StringFixture.CreateEmptyString()
            };
            
            yield return new object[]
            {
                ManagerFixture.CreateShortManagerName()
            };

            yield return new object[]
            {
                ManagerFixture.CreateLongManagerName()
            };
        }
    }
}