using UnityEngine;
using System.Collections;

public class ObjectScript : MonoBehaviour {

	public float x, z, y;
	public Vector3 v3;
	public GameObject rh;
	public GameObject lh;
	public Vector3 offset;
	public bool collision = false;
	public Vector3 rh3; 
	private BoxCollider a;
	private GameObject p;
	private Rigidbody rb;
	//public bool boolrh;
	//public bool boollh;
	//public Vector3 test;

	// Use this for initialization
	void Start () {
		//a = GetComponent<BoxCollider> ();
		p = GameObject.Find ("Terrain");
		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
//		v3 = transform.position;
//		x = v3.x;
//		z = v3.z;
//		y = v3.y;
//		rh3 = rh.transform.position;
//
//
//
//		if ((boollh && boolrh) || collision) {
//			collision = true;
//			if (offset == Vector3.zero)
//				BitteFolgen ();
//			
//			test = rh.transform.position;
//			transform.position = rh.transform.position + offset;
//			if (Input.GetButtonDown ("GameTrakButton")) {
//				if ((gameObject.GetComponent<Rigidbody> ()) == null) {
//					rb = gameObject.AddComponent<Rigidbody> () as Rigidbody;
//					collision = false;
//					boollh = false;
//					boolrh = false;
//					a.enabled = false;
//					offset = Vector3.zero;
//
//				}
//			}
//		}
//
//		if ((a.enabled == false) && ((y + 2.0) <= rh3.y)) {
//			a.enabled = true;
//		}
	}
	/*void OnCollisionEnter(Collision other)
	{
		
//		if (other.gameObject.Equals (rh)) {
//			boolrh = true; 
//		}
//
//		if (other.gameObject.Equals (lh)) {
//			boollh = true; 
//		}

		if (other.gameObject.Equals (p)) {
			if (rb==null) {
				rb = GetComponent<Rigidbody> ();
			}
			Destroy (rb);
		}
			
	}*/

//	void OnCollisionExit(Collision other)
//	{
//		if(other.gameObject.Equals(rh))
//			boolrh = false;
//
//		if(other.gameObject.Equals(lh))
//			boollh = false;
//	}



//	void BitteFolgen(){
//
//		offset = transform.position - rh.transform.position;
//	}
}
