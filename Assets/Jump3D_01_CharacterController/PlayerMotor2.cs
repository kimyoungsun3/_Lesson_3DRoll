using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump3D_01{
	[RequireComponent(typeof(CharacterController))]
	public class PlayerMotor2 : MonoBehaviour {
		public float gravity 	= -9.81f;
		public float jumpForce 	= 10f;
		public float moveSpeed 	= 3f;
		public float turnSpeed = 90f;
		//public float checkRadius = 0.01f;
		//public Transform transCheckPoint;
		//public LayerMask checkMask;
		CharacterController controller;
		Vector3 velocity;
		//bool bGround;


		void Start () {
			controller = GetComponent<CharacterController> ();
			//if (transCheckPoint == null) {
			//	transCheckPoint = transform.Find ("CheckPoint");
			//}
		}


		void Update () {
			//x
			//bGround = Physics.CheckCapsule(transform.position, transCheckPoint.position, checkRadius, checkMask);
			//x
			//bGround = Physics.Linecast(transform.position, transCheckPoint.position, checkMask);
			//x
			//bGround = Physics.Raycast(transform.position, -transform.up, checkRadius, checkMask);
			//Debug.Log (controller.isGrounded + ":" + bGround);

			velocity.y += gravity * Time.deltaTime;
			if (controller.isGrounded && Input.GetButtonDown ("Jump")) {
				velocity.y = jumpForce;
			}

			//Keyboard move + Velocity  -> Controller move
			velocity.Set (
				0, 
				velocity.y, 
				Input.GetAxisRaw ("Vertical") * moveSpeed
			);
			transform.Rotate (Vector3.up * Input.GetAxisRaw ("Horizontal") * turnSpeed * Time.deltaTime);

			//new Vector3(0, 1, 0)
			//new Vector3(0, Input.xxx * turnSpeed * Time.deltaTime, 0);


			controller.Move ( transform.rotation * velocity * Time.deltaTime);
			
		}


		void OnTriggerEnter(Collider _col){
			Debug.Log (_col.tag);
			if (_col.CompareTag ("Coin")) {
				//+1
				Coin _c1 = _col.GetComponent<Coin1>();
				if (_c1 != null) {
					Debug.Log (_c1.GetCollider ());
					_c1.InvokeInfo ();
					_c1.InvokeDestroy ();
				}
			}
		}
	}
}