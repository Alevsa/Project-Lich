﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SWeaponUI : MonoBehaviour {

    private Weaponry playerWeaponry;
    private Image thisImage;
    private bool errMessage;

    // Use this for initialization
    void Start()
    {
        playerWeaponry = GetComponentInParent<PanelController>().BoundPlayer.GetComponent<Weaponry>();
        thisImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerWeaponry == null)
        {
            if (errMessage == false)
            {
                Debug.LogError("No Weapon");
                errMessage = true;
            }
        }

        else
            thisImage.sprite = playerWeaponry.SecondaryWeapon.GetComponent<SpriteRenderer>().sprite;
    }
}
