using UnityEngine;

namespace DefaultNamespace
{
    public class FogController : MonoBehaviour
    {
        [SerializeField]
        private GameObject fogObjectLeft;
        [SerializeField]
        private GameObject fogObjectRight;
        [SerializeField]
        private float duration = 180f; // Time for the fog to fully extend

        private Vector3 initialScaleLeft;
        private Vector3 initialScaleRight;
        private float _endTime;
        private float _initialTime;
        private float _currentTime;
        private float _time;

        private void Start()
        {
            // Save initial scales
            initialScaleLeft = fogObjectLeft.transform.localScale;
            initialScaleRight = fogObjectRight.transform.localScale;
            //_initialTime = Time.time;
            //_endTime = Time.time + duration;
        }

        public void Update()
        {
            _time += Time.deltaTime;
            float t = Mathf.Clamp01(_time / duration);
            //print(_currentTime / duration);
            fogObjectLeft.transform.localScale = new Vector3(
                Mathf.Lerp(initialScaleLeft.x, initialScaleLeft.x + Mathf.Abs(fogObjectLeft.transform.position.x), t), 
                fogObjectLeft.transform.localScale.y, 
                fogObjectLeft.transform.localScale.z);
            //print(fogObjectLeft.transform.position.x); //-85
            fogObjectRight.transform.localScale = new Vector3(
                Mathf.Lerp(initialScaleRight.x, initialScaleRight.x + Mathf.Abs(fogObjectRight.transform.position.x), t), 
                fogObjectRight.transform.localScale.y, 
                fogObjectRight.transform.localScale.z);
        }
    }
}