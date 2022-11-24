using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCard : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;
    public void ChangeCardImage()
    {
        System.Random r = new System.Random();
        int rnum = r.Next(0, 3);
        image.sprite = sprites[rnum];

    }
}
