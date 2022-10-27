namespace Simofun.DevCaseStudy.Unity.DependencyInversion.Domain
{
	using Simofun.DevCaseStudy.Unity.DependencyInversion.Domain.Model;
	using System.Collections.Generic;
	using System.Linq;

	public class LeaderboardSorterByScore
	{
		#region Public Methods
		public IEnumerable<ILeaderboardItem> Sort(FakeLeaderboardProvider leaderboardProvider) =>
			leaderboardProvider.GetItems().OrderByDescending(i => i.Score);
		#endregion
	}
}
