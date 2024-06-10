using System;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public class Box : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float rotationAngle = 10f;

        #endregion


        #region Unity Events

        private void Update()
        {
            transform.Rotate(Vector3.right, rotationAngle);
        }

        #endregion


        #region Public Methods

        #endregion


        #region Private Methods

        #endregion
    }
}