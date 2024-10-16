using UnityEngine;

namespace DefaultNamespace
{
    //TODO large refactor
    public class FogController : MonoBehaviour
    {
        [SerializeField]
        private GameObject fogObjectLeft;
        [SerializeField]
        private GameObject fogObjectRight;
        [Tooltip("Time in seconds for the fog to close in")]
        [SerializeField]
        private float duration = 180f; // Time for the fog to fully extend

        private Vector3 initialPosLeft;
        private Vector3 initialPosRight;
        private float _endTime;
        private float _initialTime;
        private float _currentTime;
        private float _time;
        private BoxCollider2D _fogCollider;

        private void Start()
        {
            // Save initial scales
            initialPosLeft = fogObjectLeft.transform.position;
            initialPosRight = fogObjectRight.transform.position;
            //_initialTime = Time.time;
            //_endTime = Time.time + duration;
            _fogCollider = fogObjectLeft.GetComponentInChildren<BoxCollider2D>();
        }

        public void Update()
        {
            UpdateFogPosition();
        }

        private void UpdateFogPosition()
        {
            _time += Time.deltaTime;
            float t = Mathf.Clamp01(_time / duration);
            Vector3 currentPos = fogObjectLeft.transform.position;
            float calculatedPos = Mathf.Lerp(initialPosLeft.x, initialPosLeft.x + Mathf.Abs(currentPos.x), t);
            fogObjectLeft.transform.position = new Vector3(calculatedPos, fogObjectLeft.transform.position.y, 0);
            fogObjectRight.transform.position = new Vector3(-calculatedPos, fogObjectRight.transform.position.y, 0);
        }
    }
}