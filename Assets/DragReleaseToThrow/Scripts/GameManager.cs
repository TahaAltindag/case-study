using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Simofun.DevCaseStudy.Unity
{
    public class GameManager : MonoBehaviour
    {
        #region Fields

       
        #endregion


        #region Unity Events

        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }

        #endregion


        #region Public Methods

        #endregion


        #region Private Methods

        #endregion
    }
}