using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {//create 10 ammo pickups and 5 bots here
	public GameObject bot;
	GameObject bot1;
	public GameObject ammo;
	GameObject ammo1;
	// Use this for initialization
	void Start () {
       // GameObject leader = GameObject.FindGameObjectWithTag("leader");
       // GameObject teaser = GameObject.FindGameObjectWithTag("teaser");

      //  leader.GetComponent<StateMachine>().SwitchState(new IdleState(leader, teaser));
      //  teaser.GetComponent<StateMachine>().SwitchState(new TeaseState(teaser, leader));

      //  leader.renderer.material.color = Color.red;
       // teaser.renderer.material.color = Color.blue;

		for(int i = 0; i < 10; i++){//create 10 ammo in scene
			Vector3 victor = new Vector3 (Random.Range(-30,30), 0f , Random.Range(-30,30));//spawn at random x and z coord
			ammo1 = Instantiate(ammo, victor ,Quaternion.identity) as GameObject;
			ammo1.renderer.material.color = Color.red;
		}

		for(int i = 0; i < 5; i++){//create 5 bots in scene
			Vector3 victor = new Vector3 (Random.Range(-30,30), 0f , Random.Range(-30,30));//spawn at random x and z coord
			ammo1 = Instantiate(ammo, victor ,Quaternion.identity) as GameObject;
			ammo1.renderer.material.color = Color.blue;
		}

        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
