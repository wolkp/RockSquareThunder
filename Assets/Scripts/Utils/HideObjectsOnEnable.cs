using UnityEngine;

namespace Unity.BossRoom.Utils
{
    public class HideObjectsOnEnable : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] m_ObjectsToHide;

        private void OnEnable()
        {
            foreach (var objectToHide in m_ObjectsToHide)
            {
                objectToHide?.SetActive(false);
            }
        }
    }

}
