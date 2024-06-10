using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Simofun.DevCaseStudy.Unity.TapDragToSort.Scripts
{
    public class Placeholder : MonoBehaviour
    {
        public Sweet Sweet;

        public void SetSweet(Sweet sweet)
        {
            Sweet = sweet;
            sweet.transform.SetParent(transform);
            sweet.transform.localPosition = Vector3.zero;
            Debug.Log($"Sweet {sweet.name} set to placeholder {gameObject.name}");
        }

        public void ClearSweet()
        {
            Debug.Log($"Sweet cleared from placeholder {gameObject.name}");
            Sweet = null;
            // Update visual representation
        }

        public bool IsEmpty()
        {
            return Sweet == null;
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log($"{gameObject.name} 's place holder is called");
            var dragHandler = eventData.pointerDrag.GetComponent<DragHandler>();
            Debug.Log($" {dragHandler.gameObject.name} is dropped to " + gameObject.name);
            if (dragHandler != null)
            {
                Sweet droppedSweet = dragHandler.gameObject.GetComponent<Sweet>();
                if (IsEmpty())
                {
                    Debug.Log("on drop is empty");
                    SetSweet(droppedSweet);
                    droppedSweet.transform.SetParent(transform);
                    droppedSweet.transform.localPosition = Vector3.zero;
                    Debug.Log($"Dropped sweet {droppedSweet.name} set to new parent {transform.name}");
                }
                else
                {
                    Debug.Log("on drop else statement");
        
                    // If the placeholder is not empty, revert the dragged item back to its original position.
                    dragHandler.OnEndDrag(eventData);
                }
            }
        }

    }
}