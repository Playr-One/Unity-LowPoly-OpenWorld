using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour {

    public Transform player;
    static Animator EnemyAnimation;

	// Use this for initialization
	void Start () {

        EnemyAnimation = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(player.position, this.transform.position) < 10.0 && angle < 100.0)
        {

            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            EnemyAnimation.SetBool("IsIdle", false);
            if(direction.magnitude <= 1.8)
            {
                EnemyAnimation.SetBool("IsAttacking", true);
                EnemyAnimation.SetBool("IsWalking", false);
            }
            else
            {
                this.transform.Translate(0, 0, 0.02f);
                EnemyAnimation.SetBool("IsWalking", true);
                EnemyAnimation.SetBool("IsAttacking", false);
            }

        }
        else
        {
            EnemyAnimation.SetBool("IsIdle", true);
            EnemyAnimation.SetBool("IsWalking", false);
            EnemyAnimation.SetBool("IsAttacking", false);
        }
		
	}
}
