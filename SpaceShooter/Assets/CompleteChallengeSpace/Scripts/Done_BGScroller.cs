using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
	public float scrollSpeed;
	public float tileSizeZ;
	private bool called;

	private Vector3 startPosition;
	public Done_GameController gameController;

	void Start ()
	{
		startPosition = transform.position;
	}

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;

	if (gameController.winGame == true && called == false)
		{
			called = true;
			scrollSpeed -= 5.0f;
		}

	}
}