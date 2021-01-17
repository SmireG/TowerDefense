using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : Enemy
{

    // Update is called once per frame
    public override void Update()
    {
        if (Boss.isTouched)
        {
            Destroy(gameObject);
        }

        if (Time.timeScale == 0)
        {
            return;
        }
        canvas.transform.rotation = mainCamera.transform.rotation;
        if (hp <= 0) return;
        Move();

    }


    public override void Move()
    {
        if (positions == null) return;
        if (Vector3.Distance(positions[positions.Length - 1].position, transform.position) == 0)
        {
            Destroy(gameObject);
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



    public override void Die()
    {
        TechManage.TechPoints += 2;

        characterAnimator.SetBool("isDead", true);
        Destroy(gameObject, 2.5f);
    }
}
