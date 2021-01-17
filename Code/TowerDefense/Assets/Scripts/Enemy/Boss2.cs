using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : Enemy
{

    private float timer = 0;

    public override void Move()
    {
        if (positions == null) return;
        if (Vector3.Distance(positions[positions.Length - 1].position, transform.position) == 0)
        {
            GameManage.ShowExitPanel();

            return;
        }

        transform.localPosition = Vector3.MoveTowards(transform.position, positions[index].position, speed * 0.01f);

        if (Vector3.Distance(positions[index].position, transform.position) < 3f && index < positions.Length - 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(positions[index + 1].position - positions[index].position), 0.03f);
        }

        if (Vector3.Distance(positions[index].position, transform.position) == 0)
        {
            index++;
        }
    }


    public override void Update() { 
        if(gameObject==null){
            return;
        }
    
        if(Time.timeScale == 0)
        {
            return;
        }
        if (hp <= 0) return;
        timer += Time.deltaTime;
        canvas.transform.rotation = mainCamera.transform.rotation;

        if (timer >= 0 && timer <= 8)
        {
            characterAnimator.SetBool("isAttacking", false);
            Move();

        }
        else if (timer < 10)
        {
            characterAnimator.SetBool("isAttacking", true);
        }
        else timer = 0;


    }


    public override void OnDestroy()
    {
        TechManage.TechPoints += 100;

        GameManage.IsEnd();
    }



}
