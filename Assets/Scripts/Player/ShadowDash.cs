using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDash : MonoBehaviour
{
    private Transform _transform;
    public SpriteRenderer _parentSprite;
    private SpriteRenderer _childSprite;


    void Start()
    {
        _transform = GetComponent<Transform>();
        _parentSprite = GetComponent<SpriteRenderer>();
        _childSprite = _transform.Find("ShadowPlayer").GetComponent<SpriteRenderer>();
        _childSprite.sprite = _parentSprite.sprite;
    }
}
