namespace Orderly.Domain.UnitTests.TestUtils.Manager;

public class ManagerGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateManager()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[]
            {
                ManagerFixture.CreateManager()
            };
    }
    
    
    public static IEnumerable<object[]> CreateInvalidManagerName()
    {
        for (var i = 0; i < Rounds; ++i)
        {
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