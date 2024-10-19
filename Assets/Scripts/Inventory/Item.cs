using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
    public class Item : ScriptableObject
    {
        [SerializeField]
        protected string internalID;
        public string InternalID => internalID;

        [SerializeField]
        protected string displayName;
        public string DisplayName => displayName;

        [SerializeField, TextArea(15,20)]
        protected string description;
        public string Description => description;

        [SerializeField]
        protected Sprite sprite;
        public Sprite Sprite => sprite;
    }
}