using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	private PlayerStats playerStats;
	private Text thisText;
    private bool errMessage;

	// Use this for initialization
	void Start () {
		playerStats = GetComponentInParent<PanelController> ().BoundPlayer.GetComponent<PlayerStats>();
		thisText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerStats == null)
        {
            if(errMessage == false)
            {
				Debug.LogError ("No Stats");
				errMessage = true;
            }
        }

        else 		
            thisText.text = playerStats.Health.ToString();
	}
	
}
