using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : Enemy
{
    public override void Die()
    {
        TechManage.TechPoints += 5;

        characterAnimator.SetBool("isDead", true);
        Destroy(gameObject, 1.5f);
    }
}
