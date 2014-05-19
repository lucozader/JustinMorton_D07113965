using System;
using System.Collections.Generic;
using UnityEngine;

public class IdleState:State
{
    static Vector3 initialPos = Vector3.zero;

    //GameObject enemyGameObject;

    public override string Description()
    {
        return "Idle State";
    }

    public IdleState(GameObject myGameObject)
        : base(myGameObject)
    {
       // this.enemyGameObject = enemyGameObject;
	}
    public override void Enter()
    {
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(UnityEngine.Random.Range(-30,30), 0, UnityEngine.Random.Range(-20,20)));//create random point
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(UnityEngine.Random.Range(-30,30), 0,UnityEngine.Random.Range(-20,20)));//create second random point

        myGameObject.GetComponent<SteeringBehaviours>().path.Looped = true;            
        myGameObject.GetComponent<SteeringBehaviours>().path.draw = true;
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
        // Can I see the enemy?
		//if ((myGameObject.transform.position - myGameObject.transform.position).magnitude < range)
       // {
            // Is the leader inside my FOV
        //    myGameObject.GetComponent<StateMachine>().SwitchState(new AttackingState(myGameObject));
       // }
    }
}
