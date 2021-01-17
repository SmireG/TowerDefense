using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    public static bool isTouched = false;

    void OnTriggerEnter(Collider collider)
    {
      

        if (collider.name == "Friend(Clone)")
        {
            isTouched = true;
        }

    }

    public override void Die()
    {
        TechManage.TechPoints += 50;

        characterAnimator.SetBool("isDead", true);
        Destroy(gameObject);
    }





}
