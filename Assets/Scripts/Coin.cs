using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public int ccc = 1;
	public virtual int InvokeInfo(){
		Debug.Log (ccc);
		return ccc;
	}

	public virtual void InvokeDestroy(){
		Destroy (gameObject);
	}

	public virtual Collider GetCollider(){
		return GetComponent<Collider> ();
	}
}
