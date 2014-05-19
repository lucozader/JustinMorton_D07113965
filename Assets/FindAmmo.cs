using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class FindAmmo:State
{
	static Vector3 initialPos = Vector3.zero;
	GameObject [] allAmmo;
	//GameObject enemyGameObject;
	int temp2;
	
	
	public override string Description()
	{
		return "Find Ammo State";
	}
	
	public FindAmmo(GameObject myGameObject)
		: base(myGameObject)
	{
		// this.enemyGameObject = enemyGameObject;
		allAmmo = GameObject.FindGameObjectsWithTag("ammo");//an array with all bots in scene
		
	}
	public override void Enter()
	{
		Vector3 nearestAmmo = new Vector3();
		nearestAmmo = allAmmo[0].transform.position;
		float temp = (nearestAmmo - myGameObject.transform.position).magnitude;
		 temp2 = 0;
		for(int i = 0; i<10;i++){
			float distanceTo = (allAmmo[i].transform.position- myGameObject.transform.position).magnitude;
			if(distanceTo<temp){
				temp = distanceTo;
				temp2 = i;

			}



		}
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(allAmmo[temp2].transform.position);//go to nearest ammo coords
		//myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(UnityEngine.Random.Range(-30,30), 0,UnityEngine.Random.Range(-20,20)));//create second random point
		//myGameObject.AddComponent<LineRenderer>();
		//LineRenderer pro = myGameObject.GetComponent<LineRenderer>();//linerenderer = no need for gizmos
		//pro.SetWidth(0.4f,0.4f);
		//pro.material.color = Color.green;
		//pro.SetPosition(0,  myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints[0]);    
		//pro.SetPosition(1,  myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints[1]);          
		
		
		
		//myGameObject.GetComponent<SteeringBehaviours>().path.Looped = true;            
		//  myGameObject.GetComponent<SteeringBehaviours>().path.draw = true;  ///use linerenderer instead
		myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
		myGameObject.GetComponent<SteeringBehaviours>().FollowPathEnabled = true;
		
	}
	public override void Exit()
	{
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Clear();
	}
	
	public override void Update()
	{
		if((allAmmo[temp2].transform.position - myGameObject.transform.position).magnitude < 1){//if reach ammo dump
			myGameObject.GetComponent<Ammo>().ammo = 10;////reset ammo to 10

			myGameObject.GetComponent<StateMachine>().SwitchState(new IdleState(myGameObject));//go back to patrolling



		}
		

		
	}
}
