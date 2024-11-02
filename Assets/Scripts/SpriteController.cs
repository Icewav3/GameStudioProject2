using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] Ghosts;
    private SpriteRenderer _sprite;
    private int _index = 0;
    void Awake()
    {
        //invoked from inspector event
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    public void UpdateSprite()
    {
        _index += 1;
        // Disable the sprite if there are no more items left in the array
        if (_index >= Ghosts.Length)
        {
            _sprite.enabled = false;
            return; // Exit the method early to avoid accessing out of bounds
        }
        _sprite.sprite = Ghosts[_index];
    }
}
