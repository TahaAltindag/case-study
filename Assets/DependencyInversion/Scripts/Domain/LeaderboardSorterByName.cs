namespace Simofun.DevCaseStudy.Unity.DependencyInversion.Domain
{
    using Simofun.DevCaseStudy.Unity.DependencyInversion.Domain.Model;
    using System.Collections.Generic;
    using System.Linq;

    public class LeaderboardSorterByName : ILeaderboardSorter
    {
        #region Public Methods

        public IEnumerable<ILeaderboardItem> Sort(IEnumerable<ILeaderboardItem> items) =>
            items.OrderBy(i => i.Name);

        #endregion
    }
}