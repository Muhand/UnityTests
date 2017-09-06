using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    [SerializeField]
    GameObject Target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Get target's position
        Vector2 target_pos = Target.transform.position;

        //Our position
        Vector2 our_pos = transform.position;

        //Calculate difference
        Vector2 diff = target_pos - our_pos;

        //Calculate Angle
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        //Change only the z because this is 2D
        transform.rotation = Quaternion.Euler(0, 0, angle);


	}
}
