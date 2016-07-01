using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public bool rh, lh;
	private GameObject lhCollisionObject;
	private GameObject rhCollisionObject;
	//GameObject rightHand = GameObject.FindWithTag("RightHand");
	GameObject leftHand;


	// Use this for initialization
	void Start () {

		leftHand = GameObject.FindWithTag("LeftHand");

	}

	// Update is called once per frame
	void Update () {
//		if (lh == true && rh == true && lhCollisionObject.Equals (rhCollisionObject)) {
//			
//		}
	}

	public void SetHandAndCollisionObject(GameObject hand, GameObject obj)
	{
		if (hand.Equals (leftHand)) {
			lh = true;
			lhCollisionObject = obj;
			}
		else {
			rh = true;
			rhCollisionObject = obj;
		}


	}

	public GameObject GetCollisionObject()
	{
		if (lh == true && rh == true && lhCollisionObject.Equals (rhCollisionObject) && !(rhCollisionObject.Equals (null) && lhCollisionObject.Equals (null)))
		//if (lhCollisionObject != null && lhCollisionObject.Equals (rhCollisionObject))
			return lhCollisionObject;
		else
			return null;
	}

	public void SetFalse(GameObject hand)
	{
		if (hand.Equals (leftHand)) {
			lh = false;
		}
		else {
			rh = false;
		}
	}
}
