namespace Simofun.DevCaseStudy.Unity.DependencyInversion.Domain
{
	using Simofun.DevCaseStudy.Unity.DependencyInversion.Domain.Model;
	using System.Collections.Generic;
	using UnityEngine;

	public class LeaderboardController
	{
		#region Public Methods
		public IEnumerable<ILeaderboardItem> GetItems()
		{
			var leaderboardProvider = new FakeLeaderboardProvider();
			var sortType = PlayerPrefs.GetInt("SortType", 0);
			if (sortType == 0)
			{
				return new LeaderboardSorterByScore().Sort(leaderboardProvider);
			}

			return new LeaderboardSorterByName().Sort(leaderboardProvider);
		}
		#endregion
	}
}
