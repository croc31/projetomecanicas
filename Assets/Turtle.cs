using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Turtle : MonoBehaviour
{
    public EnemyCombat enemyCombat;
    public Animator animator;
    public AIPath aiPath;

    void Start()
    {
        aiPath = GetComponent<AIPath>();
        animator = GetComponent<Animator>();
        enemyCombat = GetComponent<EnemyCombat>();
        animator.SetBool("seePlayer", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)//moving to the right
        {
            animator.SetBool("moveRight", true);
            animator.SetBool("moveLeft", false);
            //Debug.Log("Right");
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)//moving to the left
        {
            animator.SetBool("moveRight", false);
            animator.SetBool("moveLeft", true);
            //Debug.Log("Left");
        }
        //animator.SetTrigger("Attack"); //Quando a tartaruga tiver uma animação de ataque (se tiver)
        enemyCombat.Attack();
    }
}
