using UnityEngine;

namespace DefaultNamespace
{
    public class FogController : MonoBehaviour
    {

        [Tooltip("Time in seconds for the fog to close in")]
        [SerializeField]
        private float duration = 180f; // Time for the fog to fully extend
        [SerializeField]
        private bool flipX;
        private Vector3 _initialPos;
        private float _endTime;
        private float _initialTime;
        private float _currentTime;
        private float _time;
        private GameObject fogObject;
        private bool isPaused = false;
        private BoxCollider2D _fogCollider;
        public bool IsPaused
        {
            get
            {
                Debug.Log($"{nameof(IsPaused)} getter called. Value: {isPaused}");
                return isPaused;
            }
            set
            {
                isPaused = value;
                Debug.Log($"{nameof(IsPaused)} setter called. New Value: {isPaused}");
            }
        }
        private void Awake()
        {
            fogObject = this.gameObject;
            _initialPos = fogObject.transform.position;
            _fogCollider = fogObject.GetComponentInChildren<BoxCollider2D>();
        }

        public void Update()
        {
            if(!isPaused)
            {
                UpdateFogPosition();
            }
        }

        /// <summary>
        /// Updates the position of the fog object over time, causing it to gradually move.
        /// The movement is influenced by the specified duration and the current time.
        /// Depending on the flipX setting, the fog can move in the positive or negative direction along the x-axis.
        /// </summary>
        private void UpdateFogPosition()
        {
            _time += Time.deltaTime;
            float t = Mathf.Clamp01(_time / duration);
            Vector3 currentPos = fogObject.transform.position;
            float calculatedPos = Mathf.Lerp(_initialPos.x, _initialPos.x + (flipX ? -1 : 1) * -Mathf.Abs(currentPos.x), t);
            fogObject.transform.position = new Vector3(calculatedPos, fogObject.transform.position.y, 0);
        }
    }
}