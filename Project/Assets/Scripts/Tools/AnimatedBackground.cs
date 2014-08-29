using UnityEngine;
using System.Collections;

public class AnimatedBackground : MonoBehaviour {

	public int materialIndex = 0;
	public Vector2 AnimationRate = new Vector2 (0.0f, 1.0f);
	public string TextureName = "_MainTex";

	private Vector2 offset = Vector2.zero;

	// Use this for initialization
	void Start () {
		renderer.sortingLayerName = "Background";
		renderer.sortingOrder = 1;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		offset += (AnimationRate * Time.deltaTime);

		if (renderer.enabled)
		{
			renderer.materials[ materialIndex ].SetTextureOffset( TextureName, offset);
		}
	}
}