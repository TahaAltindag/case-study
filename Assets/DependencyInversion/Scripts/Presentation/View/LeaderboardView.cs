namespace Simofun.DevCaseStudy.Unity.DependencyInversion.Presentation.View
{
    using Simofun.DevCaseStudy.Unity.DependencyInversion.Domain;
    using Simofun.DevCaseStudy.Unity.DependencyInversion.Domain.Model;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public class LeaderboardView : MonoBehaviour
    {
        #region Fields

        private int index;

        #endregion

        #region Unity Methods

        protected virtual void Start()
        {
            ILeaderboardSorter sorter;
            var sortType = PlayerPrefs.GetInt("SortType", 0);

            if (sortType == 0)
            {
                sorter = new LeaderboardSorterByScore();
            }
            else
            {
                sorter = new LeaderboardSorterByName();
            }

            var leaderboard = new LeaderboardController(sorter, new FakeLeaderboardProvider());
            leaderboard.GetItems()
                .ToList()
                .ForEach(i => Debug.Log(this.PrintLeaderboardItem(i)));
        }

        #endregion

        #region Methods

        string PrintLeaderboardItem(ILeaderboardItem leaderboardItem)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Index: {++this.index}, ");
            stringBuilder.Append($"{nameof(ILeaderboardItem.Name)}: {leaderboardItem.Name}, ");
            stringBuilder.Append($"{nameof(ILeaderboardItem.Score)}: {leaderboardItem.Score}, ");

            return stringBuilder.ToString();
        }

        #endregion
    }
}