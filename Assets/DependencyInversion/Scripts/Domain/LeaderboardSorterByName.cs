namespace Simofun.DevCaseStudy.Unity.DependencyInversion.Domain
{
	using Simofun.DevCaseStudy.Unity.DependencyInversion.Domain.Model;
	using System.Collections.Generic;
	using System.Linq;

	public class LeaderboardSorterByName
	{
		#region Public Methods
		public IEnumerable<ILeaderboardItem> Sort(FakeLeaderboardProvider leaderboardProvider) =>
			leaderboardProvider.GetItems().OrderBy(i => i.Name);
		#endregion
	}
}
