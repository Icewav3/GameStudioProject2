using UnityEngine;

namespace DefaultNamespace
{
    public class SunflowerCollider : MonoBehaviour
    {
        private FogController _fogController;
        private void OnTriggerEnter2D(Collider2D other)
        {
            var a = other.GetComponentInChildren<FogController>();
            if (a)
            {
                _fogController = a;
                _fogController.IsPaused = true;
            }
        }

        private void OnDestroy()
        {
            print("i die");
            print(_fogController);
            if (_fogController)
            {
                _fogController.IsPaused = false;
            }
        }
    }
}