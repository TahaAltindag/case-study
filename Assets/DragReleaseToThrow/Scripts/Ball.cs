using System;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Ball : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float forceMultiplier = 3;
        [SerializeField] private bool revertDirection;
        [SerializeField] private float minMagnitude = 0f;
        [SerializeField] private float maxMagnitude = 250f;
        private Vector3 mousePressDownPos;
        private Vector3 mouseReleasePos;
        private Rigidbody rb;
        private bool isShoot;
        public static event Action<float, Vector3> OnMagnitudeCalculated;

        #endregion


        #region Unity Events

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnMouseDown()
        {
            mousePressDownPos = Input.mousePosition;
        }

        private void OnMouseDrag()
        {
            var currentMousePos = Input.mousePosition;
            var dir = revertDirection ? currentMousePos - mousePressDownPos : mousePressDownPos - currentMousePos;
            float currentMagnitude = dir.magnitude;

            float clampedMagnitude = Mathf.Clamp(currentMagnitude, minMagnitude, maxMagnitude);
            Debug.Log(clampedMagnitude);
            OnMagnitudeCalculated?.Invoke(clampedMagnitude, dir);
        }

        private void OnMouseUp()
        {
            // if (isShoot)
            //     return;
            mouseReleasePos = Input.mousePosition;
            var dir = revertDirection ? mouseReleasePos - mousePressDownPos : mousePressDownPos - mouseReleasePos;
            Shoot(dir);
        }

        private void Shoot(Vector3 force)
        {
            var trajectory = new Vector3(force.x, force.y, force.y);
            rb.AddForce(trajectory * forceMultiplier);
            isShoot = true;
        }

        #endregion


        #region Public Methods

        #endregion


        #region Private Methods

        #endregion
    }
}