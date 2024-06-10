namespace Simofun.DevCaseStudy.Unity.DependencyInversion.Domain
{
    using Simofun.DevCaseStudy.Unity.DependencyInversion.Domain.Model;
    using System.Collections.Generic;
    using UnityEngine;

    public class LeaderboardController
    {
        #region Fields

        private readonly ILeaderboardSorter _sorter;
        private readonly FakeLeaderboardProvider _leaderboardProvider;

        #endregion

        #region Constructor

        public LeaderboardController(ILeaderboardSorter sorter, FakeLeaderboardProvider leaderboardProvider)
        {
            _sorter = sorter;
            _leaderboardProvider = leaderboardProvider;
        }

        #endregion

        #region Public Methods

        public IEnumerable<ILeaderboardItem> GetItems()
        {
            var items = _leaderboardProvider.GetItems();
            return _sorter.Sort(items);
        }

        #endregion
    }
}