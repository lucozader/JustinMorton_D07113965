using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class IdleState:State
{
	static Vector3 initialPos = Vector3.zero;
	GameObject [] allBots;
	//GameObject enemyGameObject;



    public override string Description()
    {
        return "Idle State";
    }

    public IdleState(GameObject myGameObject)
        : base(myGameObject)
    {
       // this.enemyGameObject = enemyGameObject;
		allBots = GameObject.FindGameObjectsWithTag("bot");//an array with all bots in scene

	}
    public override void Enter()
    {
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(UnityEngine.Random.Range(-30,30), 0, UnityEngine.Random.Range(-20,20)));//create random point
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(UnityEngine.Random.Range(-30,30), 0,UnityEngine.Random.Range(-20,20)));//create second random point
		if(myGameObject.GetComponent<LineRenderer>() == null){
			myGameObject.AddComponent<LineRenderer>();}
		LineRenderer pro = myGameObject.GetComponent<LineRenderer>();//linerenderer = no need for gizmos
		pro.SetWidth(0.4f,0.4f);
		pro.material.color = Color.green;
		pro.SetPosition(0,  myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints[0]);    
		pro.SetPosition(1,  myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints[1]);          



        myGameObject.GetComponent<SteeringBehaviours>().path.Looped = true;            
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

        float range = 5.0f; 
		float findSame = 0.5f;//find which bot in array this gameobject is//don't want to shoot self!
        // Can I see the enemy?
		for(int i = 0; i<5; i++){//check all bots
			if (((allBots[i].transform.position - myGameObject.transform.position).magnitude < range)&&((allBots[i].transform.position - myGameObject.transform.position).magnitude>findSame)){
				   myGameObject.GetComponent<StateMachine>().SwitchState(new AttackingState(myGameObject,allBots[i]));//if bot in range go to attacking state

			}
		

		}
	
    }
}
