using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public abstract class Sweet : MonoBehaviour
    {
        #region Fields

        public string Name { get; private set; }

        #endregion


        #region Constructor

        protected Sweet(string name)
        {
            Name = name;
        }

        #endregion
    }
}