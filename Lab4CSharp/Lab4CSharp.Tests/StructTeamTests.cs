using Xunit;

namespace Lab4CSharp.Tests;

public class SportTeamTests
{
    [Fact]
    public void TestTeamFiltering()
    {
        var teams = new List<SportTeamStruct>
        {
            new SportTeamStruct { Name = "A", Points = 10 },
            new SportTeamStruct { Name = "B", Points = 50 }
        };

        int minPoints = 30;
        teams.RemoveAll(t => t.Points < minPoints);

        Assert.Single(teams);
        Assert.Equal("B", teams[0].Name);
    }
}