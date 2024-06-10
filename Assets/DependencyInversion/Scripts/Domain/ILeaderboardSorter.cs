namespace Simofun.DevCaseStudy.Unity.DependencyInversion.Domain
{
    using Simofun.DevCaseStudy.Unity.DependencyInversion.Domain.Model;
    using System.Collections.Generic;

    public interface ILeaderboardSorter
    {
        IEnumerable<ILeaderboardItem> Sort(IEnumerable<ILeaderboardItem> items);
    }
}