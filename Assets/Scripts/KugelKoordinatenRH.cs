using UnityEngine;
using System.Collections;

public class KugelKoordinatenRH : MonoBehaviour {

	public float moveSpeed = 10f;
	public float shifter = 0f;
	private const int maxGrad = 120;
	public GameObject cube;
	public Vector3 offset;
	private Transform t;
	GameObject gameControllerObject;
	GameController gameController;
	GameObject thisGameObject;
	GameObject terrain;
	GameObject lh;
	Rigidbody rb;

	void Start()
	{
		gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
		thisGameObject = GameObject.Find ("RightHand");
		terrain = GameObject.Find("Terrain");
		lh = GameObject.Find ("LeftHand");

	}
		
	void Update()
	{
		float x1 = Input.GetAxis("GameTrak RX"); // winkel 1
		float y1 = Input.GetAxis("GameTrak RY"); // radius
		float z1 = Input.GetAxis("GameTrak RZ"); // winkel 2

		float radius = (float)((y1 + 1) * 1f + shifter) * 3;
		float winkel1 = x1 * maxGrad; // from -maxGrad to +maxGrad grad
		float winkel2 = z1 * maxGrad;

		float radians_a = (float)(winkel1 / 360 * 2.0 * Mathf.PI); // grad to radiant 
		float radians_b = (float)(winkel2 / 360 * 2.0 * Mathf.PI);

		transform.rotation = Quaternion.Euler(winkel2+90, 0, -winkel1);
		//transform.Rotate(0, 0, 90);

		// umrechnung von gametrak kugelkoordinaten 
		float real_x = radius * Mathf.Sin(radians_a) * Mathf.Cos(radians_b);
		float real_z = radius * Mathf.Cos(radians_a) * Mathf.Sin(radians_b);
		float real_y = radius * Mathf.Cos(radians_a) * Mathf.Cos(radians_b);

		transform.position = new Vector3(real_x * moveSpeed - 1.0f, real_y * moveSpeed, real_z * moveSpeed);

	}

	void OnCollisionEnter(Collision other)
	{
		if (!other.gameObject.Equals (terrain) && (!other.gameObject.Equals(lh))) {
			rb = other.gameObject.GetComponent<Rigidbody> ();
			Destroy (rb);
			gameController.SetHandAndCollisionObject (thisGameObject, other.gameObject);
		}
	}
		
	void OnCollisionExit(Collision other)
	{
		if (!other.gameObject.Equals (terrain) && (!other.gameObject.Equals(lh))) {
			gameController.SetFalse(thisGameObject);
		}
	}
}

