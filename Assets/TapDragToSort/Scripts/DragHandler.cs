using UnityEngine;
using UnityEngine.EventSystems;

namespace Simofun.DevCaseStudy.Unity.TapDragToSort.Scripts
{
    public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        #region Fields

        private Vector3 startPosition;
        private Transform startParent;
        private CanvasGroup canvasGroup;
        private Camera mainCamera;
        private float initialZ;
        private Placeholder originalPlaceholder;

        #endregion

        private void Awake()
        {
             canvasGroup = GetComponent<CanvasGroup>();
            mainCamera = Camera.main;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            startPosition = transform.position;
            initialZ = startPosition.z;
            startParent = transform.parent;

            originalPlaceholder = startParent.GetComponent<Placeholder>();

            if (originalPlaceholder != null)
            {
                originalPlaceholder.ClearSweet(); // Clear the sweet from the original placeholder
            }

            canvasGroup.blocksRaycasts = false;
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast"); // Set to IgnoreRaycast layer
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("on drag");

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log(hit.transform.gameObject.name);
                Vector3 newPosition = hit.point;
                newPosition.z = initialZ; // Keep the Z position constant
                transform.position = newPosition;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            
            if (transform.parent == startParent)
            {
                transform.position = startPosition;
                if (originalPlaceholder != null)
                {
                    originalPlaceholder.SetSweet(GetComponent<Sweet>());
                }
            }

            canvasGroup.blocksRaycasts = true; // Re-enable raycasts after drag
            gameObject.layer = LayerMask.NameToLayer("Default"); // Reset to Default layer
        }
    }
}