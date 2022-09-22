using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteColor : MonoBehaviour
{
    public Color color;
    [HideInInspector] public SpriteRenderer flockSprite;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        flockSprite = collision.gameObject.GetComponentInChildren<SpriteRenderer>();
        flockSprite.color = color;
        collision.gameObject.SetActive(false);
    }

}
