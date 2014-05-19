using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int health;
	bool once = false;
	float timer = 0;
	public AudioClip scream;
	// Use this for initialization
	void Start () {
		health = 10;
	}
	
	// Update is called once per frame
	void Update () {
		timer = timer+Time.deltaTime;
		if(health<=0){//destroy bot if health <= 0
		
		//audio.PlayOneShot(scream);//play scream
		Destroy(gameObject);//destroy gameobject
		}
	
	}
}
