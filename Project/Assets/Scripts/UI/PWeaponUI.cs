using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PWeaponUI : MonoBehaviour {

    private Weaponry playerWeaponry;
    private GameObject primaryWeapon;
    private Weapon primaryWeaponScript;
    private Image thisImage;
    private Text upgradeLevel;
    private bool errMessage;

    // Use this for initialization
    void Start()
    {
        upgradeLevel = GetComponentInChildren<Text>();
        thisImage = GetComponent<Image>();
        newWeapon();
    }

    public void newWeapon()
    {
        playerWeaponry = GetComponentInParent<PanelController>().BoundPlayer.GetComponent<Weaponry>();
        primaryWeapon = playerWeaponry.PrimaryWeapon;
        primaryWeaponScript = primaryWeapon.GetComponent<Weapon>();

        if (playerWeaponry == null)
        {
            if (errMessage == false)
            {
                Debug.LogError("No Weapon");
                errMessage = true;
            }
        }

        else
        {
            thisImage.sprite = primaryWeapon.GetComponent<SpriteRenderer>().sprite;

            if (primaryWeaponScript.Name.Contains("Dual"))
                upgradeLevel.text = "II";
            else if (primaryWeaponScript.Name.Contains("Quad"))
                upgradeLevel.text = "IIII";
            else
                upgradeLevel.text = "I";

            if (primaryWeaponScript.Name.Contains("Upgraded"))
                upgradeLevel.color = Color.magenta;
            else
                upgradeLevel.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
