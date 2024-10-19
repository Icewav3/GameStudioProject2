using UnityEngine;

namespace DefaultNamespace
{
    public class SunflowerCollider : MonoBehaviour
    {
        private FogController _fogController;
        private void OnTriggerEnter(Collider other)
        {
            _fogController = other.GetComponent<FogController>();
            if (_fogController)
            {
                _fogController.IsPaused = true;
            }
        }

        private void OnDestroy()
        {
            if (_fogController)
            {
                _fogController.IsPaused = false;
            }
        }
    }
}