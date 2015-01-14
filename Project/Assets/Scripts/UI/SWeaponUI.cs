using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SWeaponUI : MonoBehaviour {

    private Weaponry playerWeaponry;
    private Text thisText;
    private bool errMessage;

    // Use this for initialization
    void Start()
    {
        playerWeaponry = GetComponentInParent<PanelController>().BoundPlayer.GetComponent<Weaponry>();
        thisText = GetComponent<Text>();
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
            thisText.text = playerWeaponry.SecondaryWeapon.GetComponent<Weapon>().Name;
    }
}
