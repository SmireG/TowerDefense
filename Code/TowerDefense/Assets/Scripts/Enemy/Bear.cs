using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Enemy
{

   


    public override void Die()
    {
        TechManage.TechPoints+=5;
        characterAnimator.SetBool("isDead", true);
        Destroy(gameObject, 2f);
    }

}
