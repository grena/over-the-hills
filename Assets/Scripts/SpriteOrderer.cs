using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrderer : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    void Start () {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    // Source: https://forum.unity3d.com/threads/dynamic-draw-order-or-2d-z-buffer.220231/
    private void LateUpdate()
    {
        spriteRenderer.sortingOrder = (int)Camera.main.WorldToScreenPoint(spriteRenderer.bounds.min).y * -1;
    }
}
