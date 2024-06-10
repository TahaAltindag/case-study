using System;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public class Arrow : MonoBehaviour
    {
        #region Fields

        [Range(0, 0.5f)] [SerializeField] private float localZSize;

        #endregion


        #region Unity Events

        private void OnEnable()
        {
            Ball.OnMagnitudeCalculated += SetArrow;
        }

        private void OnDisable()
        {
            Ball.OnMagnitudeCalculated -= SetArrow;
        }

        #endregion


        #region Public Methods

        #endregion


        #region Private Methods

        void SetArrow(float magnitude, Vector3 direction)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, magnitude / 250f);

            direction.z = direction.y;  // Align with y-axis
            direction = Vector3.ProjectOnPlane(direction, Vector3.up);
            transform.LookAt(direction);
        }

        #endregion
    }
}