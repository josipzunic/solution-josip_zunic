using AcademyTask.Domain.Entities.User;
using Xunit;
using Assert = Xunit.Assert;

namespace TestProject1;

public class UserUnitTests
{
    [Fact]
    public void Create_WithTooShortUsername_ReturnsValidationError()
    {
        //Arange
        var shortUsername = "a";
        
        //Act
        var result = User.Create(shortUsername, "hash", "test@test.com");
        
        //Assert
        Assert.True(result.ValidationResult.HasErrors);

    }
}