using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {


	[SerializeField] private float speed;
	[SerializeField] private GameObject stage;
	private bool isInstantiateLine = false;
	
	// Update is called once per frame
	void Update () {
		if(GameController_1.isGame){
			MoveFloor();
		}
	}
	public void MoveFloor(){
		transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z-speed);
	}
	void OnTriggerEnter(Collider collider)
    {
		if(collider.gameObject.tag=="Stage"){
			Destroy(this.gameObject);
		}
    }
	void OnTriggerExit(Collider collider) 
    {
		if(collider.gameObject.tag=="InstantiateLine"){
			Vector3 stagePos = new Vector3(this.transform.position.x,this.transform.position.y,GameController_1.FirstStageNumber* this.transform.localScale.z-speed-0.2f);
			GameObject NextStage = Instantiate (stage,stagePos, transform.rotation) as GameObject;
			NextStage.name = "stage";
    	}
	}
}
