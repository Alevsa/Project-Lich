using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

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
            if(errMessage == false)
            {
				errMessage = true;
            }

		if (playerStats.Score > int.Parse (thisText.text))
		{
				int difference = playerStats.Score - int.Parse (thisText.text);
				
				if ((difference/10) > 0)
					thisText.text = (int.Parse (thisText.text) + difference/10).ToString().PadLeft (thisText.text.Length,'0');
				else
					thisText.text = (int.Parse (thisText.text) + difference).ToString ().PadLeft(thisText.text.Length,'0');
		}
	}
}
