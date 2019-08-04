using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
	public float scrollSpeed;
	public float tileSizeZ;
	private bool called;

	private Vector3 startPosition;

	void Start ()
	{
		startPosition = transform.position;
	}

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;

	if (Done_GameController.winGame == true && called == false)
		{
			called = true;
			scrollSpeed -= 15.0f;
		}

	}
}