using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.UI;

public class CardSystem : MonoBehaviour
{

    public GameObject[] buttons;
    public GameObject[] minions;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        ChangeCards();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeCards()
    {
        System.Random r = new System.Random();
        
        for (int i = 0; i < buttons.Length; i++)
        {
            int rnum = r.Next(0, 3);
            buttons[i].GetComponent<Image>().sprite = sprites[rnum];
        }
    }


    public void ChangeCard()
    {
        System.Random r = new System.Random();
        int rnum = r.Next(0, 3);
        print(rnum);
        this.gameObject.GetComponent<Image>().sprite = null;//sprites[rnum];

    }

}
