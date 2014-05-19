using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Lazer:MonoBehaviour
{
	GameObject [] allBots;

	public void Start(){
	allBots = GameObject.FindGameObjectsWithTag("bot");//an array with all bots in scene

	}
    public void Update()
    {
        float speed = 5.0f;
        float width = 500;
        float height = 500;

        if ((transform.position.x < -(width / 2)) || (transform.position.x > width / 2) || (transform.position.z < -(height / 2)) || (transform.position.z > height / 2) || (transform.position.y < 0) || (transform.position.y > 100))
        {
            Destroy(gameObject);
        }
        transform.position += transform.forward * speed;
        //Debug.DrawLine(transform.position, transform.position + transform.forward * 10.0f, Color.red);//use linerenderer instead
		LineRenderer pro = gameObject.GetComponent<LineRenderer>();
		pro.SetWidth(0.4f,0.4f);
		pro.material.color = Color.red;
		pro.SetPosition(0,  transform.position);    
		pro.SetPosition(1,  transform.position + transform.forward * 10.0f);  

	
		foreach(GameObject go in allBots){///see if bot hit by lazer here
			if((go.transform.position-transform.forward * 10.0f).magnitude<1){
				go.GetComponent<Health>().health -= 1;//subtract 1 health from bot if hit by lazer
				Destroy(gameObject);//destroy lazer
				//if(go.GetComponent<Health>().health<=0){//destroy bot if health <= 0
					//Destroy(go);
				//}
			}

		}


    }
}
