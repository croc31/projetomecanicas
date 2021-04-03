using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Turtle : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;
    void Start()
    {
        aiPath = GetComponent<AIPath>();
        animator = GetComponent<Animator>();
        animator.SetBool("seePlayer", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)//moving to the rigth
        {
            animator.SetBool("moveRigth", true);
            animator.SetBool("moveLeft", false);
            Debug.Log("Rigth");
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)//moving to the left
        {
            animator.SetBool("moveRigth", false);
            animator.SetBool("moveLeft", true);
            Debug.Log("Left");
        }
    }
}
