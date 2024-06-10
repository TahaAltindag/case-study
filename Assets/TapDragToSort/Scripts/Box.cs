using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.TapDragToSort.Scripts
{
    public class Box : MonoBehaviour
    {
        [SerializeField] private Placeholder[] placeholders;

        private void Start()
        {
            placeholders = GetComponentsInChildren<Placeholder>();
        }

        public bool IsComplete()
        {
            if (placeholders.Length == 0) return false;

            Sweet firstSweet = placeholders[0].Sweet;
            if (firstSweet == null) return false;

            foreach (var placeholder in placeholders)
            {
                if (placeholder.Sweet == null || placeholder.Sweet.GetType() != firstSweet.GetType())
                {
                    return false;
                }
            }

            return true;
        }
    }
}