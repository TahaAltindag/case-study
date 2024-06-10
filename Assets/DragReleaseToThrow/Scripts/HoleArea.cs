using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public class HoleArea : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float maxAttractionForce = 10f; 
        [SerializeField] private float attractionRadius = 5f; 

        #endregion


        #region Unity Events

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Ball")) 
            {
                var ballRb = other.GetComponent<Rigidbody>();

               
                Vector2 directionToHole = transform.position - other.transform.position;
                var distanceToHole = directionToHole.magnitude;

                
                var attractionForce = maxAttractionForce * (1 - Mathf.Clamp01(distanceToHole / attractionRadius));

                // Çekim gücünü kuvvet vektörüne dönüştür
                var attractionVector = directionToHole.normalized * attractionForce;

                // Topun Rigidbody'sine kuvveti uygula
                ballRb.AddForce(attractionVector);
            }
        }

        #endregion


        #region Public Methods

        #endregion


        #region Private Methods

        #endregion
    }
}