using UnityEngine;
using System.Collections;
using System;

public class HandController : MonoBehaviour {

	public Vector3 centre;
	public Vector3 lh;
	public Vector3 rh;
	private Transform lht, rht;
	bool touched = false;
	GameObject collisionObject;
	GameController gameController;
	GameObject gameControllerObject;
	Vector3 offset;
	Vector3 distance;
	double collisionObjectlength;
	private BoxCollider collisionObjectBox;
	Rigidbody collisionObjectRigidbody;
	Vector3 collisionBox;
	GameObject lastObject;


	// Use this for initialization
	void Start () {
		lht = GameObject.FindWithTag ("LeftHand").GetComponent<Transform>();

		rht = GameObject.FindWithTag ("RightHand").GetComponent<Transform>();

		gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();


	}
	
	// Update is called once per frame
	void Update () {
		lh = lht.position;
		rh = rht.position;
		centre = (lh + rh) / 2;

		//if (collisionObject = null)
		collisionObject = gameController.GetCollisionObject (); //CollisionObjekt auf Variable und auf Last Objekt abfragen!!
		if (collisionObject != null) {

			//Destroy (collisionObjectRigidbody);
			//Collider ausschalten
			/*lht.GetComponent<Collider> ().enabled = false;
			rht.GetComponent<Collider> ().enabled = false;*/

			if (offset == Vector3.zero) {
				offset = PleaseFollow (collisionObject);
				touched = true; 
				//collisionObjectBox = collisionObject.GetComponent<BoxCollider> ();
				//collisionObjectBox.size.Set(collisionObjectBox.size.x * 1.5f, collisionObjectBox.size.y * 1.5f, collisionObjectBox.size.z * 1.5f);
				lastObject = collisionObject;
				collisionObjectBox = collisionObject.GetComponent<BoxCollider> () as BoxCollider;
				collisionObjectBox.size = new Vector3 (collisionObjectBox.size.x * 1.5f, collisionObjectBox.size.y * 1.5f, collisionObjectBox.size.z * 1.5f);
			}

			collisionObject.transform.position = centre;

			if ((lht.position.x - rht.position.x) > (collisionObjectlength * 1.5)) {
				resetObjektSettings ();
				/*lht.GetComponent<Collider> ().enabled = true;
				rht.GetComponent<Collider> ().enabled = true;*/
			} else if ((lht.position.x - rht.position.x) < (collisionObjectlength * 0.3)) {
				resetObjektSettings ();
				/*offset = Vector3.zero;
				distance = Vector3.zero;
				collisionObjectlength = 0;
				collisionObject.SetActive (false);
				gameController.SetFalse ();
				lht.GetComponent<Collider> ().enabled = true;
				rht.GetComponent<Collider> ().enabled = true;*/
			}

		} else if (collisionObject == null && touched == true){

			//resetObjektSettings ();
		}

		//else if set ative (check)
		//collider von dem gehobenen Objekt * 1.5 
		//if-Abfrage, ob länge 1.5 löschen
		//farbunterstützung 
		//Aufheben auf länge prüfen 
		//Mittelwertberechnung
		//Menü 
		//running man perfektionieren(so halb halt)

	}

	Vector3 PleaseFollow(GameObject gameObject)
	{
        collisionObjectlength = gameObject.GetComponent<Transform>().localScale.x;
		return collisionObject.transform.position - centre;
	}

	double getLength(Vector3 distance)
	{
		return Math.Sqrt(Math.Pow(distance.x,2)+Math.Pow(distance.y,2)+Math.Pow(distance.z,2));
	}

	void resetObjektSettings(){
		collisionObjectRigidbody = lastObject.AddComponent<Rigidbody> () as Rigidbody;
		offset = Vector3.zero;
		distance = Vector3.zero;
		collisionObjectlength = 0;
		lastObject = null;
		touched = false;
		collisionObjectBox.size = new Vector3 (collisionObjectBox.size.x / 1.5f, collisionObjectBox.size.y / 1.5f, collisionObjectBox.size.z / 1.5f);
		//gameController.SetFalse ();
	}

}
