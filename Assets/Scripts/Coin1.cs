using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin1 : Coin {
	public override int InvokeInfo(){
		base.InvokeInfo ();
		Debug.Log (111);
		return ccc;
	}
}
