using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed = 10f;
	public GameObject bullet;
	public GameControlScript control;
	public float bulletThreshold = 0.5f;
	float elapsedTime = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		elapsedTime += Time.deltaTime;
		transform.Translate (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0f, 0f);
		if (Input.GetButtonDown ("Jump")) 
		{
			if(elapsedTime > bulletThreshold)
			{
				Instantiate (bullet, new Vector3(transform.position.x, transform.position.y + 1.2f, -5f), Quaternion.identity);

				elapsedTime = 0f;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Destroy (other.gameObject);
		control.PlayerDied ();
		Destroy (this.gameObject);
	}
}
