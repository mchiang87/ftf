using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectible
{
    public Sprite emptyChest;
    public int markAmount = 10;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GameManager.instance.marks += markAmount;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+" + markAmount + " marks", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }
    }
}
