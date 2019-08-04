using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float timePassed;
	public float nextFire;
	Collider enemyCollide;
	private Rigidbody rb;
	

	private void Start ()
	{
		rb = GetComponent<Rigidbody>();
		timePassed = 3.0f;
		enemyCollide = GameObject.Find("Enemy").GetComponent<Collider>();
	}
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}

	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);

		if (Done_GameController.winGame == true)
		{
			transform.Translate(Vector3.forward * Time.deltaTime * speed/2);
		}
	}

	public void winMove ()
	{
		boundary.zMax = 40.0f;
		enemyCollide.isTrigger =  false;
	}

	IEnumerator IncreasedFire ()
	{
			float time = 0;
			while (time < timePassed)
		{
			timePassed += Time.deltaTime;
			fireRate = 0.1f;
			yield return null;
		}
		
			fireRate = 1.50f;
	}
	

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Powerup 1"))
		{
			other.gameObject.SetActive (false);
			StartCoroutine("IncreasedFire");
		}
	}
}
