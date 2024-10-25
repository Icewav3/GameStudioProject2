using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] Ghosts;
    private SpriteRenderer _sprite;
    private int _index = 1; //why the hell does this not start at 0 when indexing sprites?????
    void Awake()
    {
        //invoked from inspector event
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    public void UpdateSprite()
    {
        _index += 1;
        _sprite.sprite = Ghosts[_index];
        //this is cuz i think somone will break it
        if (_index > 3)
        {
            _sprite.enabled = false;
        }
    }
}
