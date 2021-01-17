using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagul : Enemy
{
    public override void Move()
    {
        if (positions == null) return;
        if (Vector3.Distance(positions[positions.Length - 1].position, transform.position) == 0)
        {
            GameManage.ShowExitPanel();
            Destroy(gameObject);

            return;
        }

        transform.localPosition = Vector3.MoveTowards(transform.position, positions[index].position, speed * 0.01f);

        if (Vector3.Distance(positions[index].position, transform.position) < 3f && index < positions.Length - 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(positions[index + 1].position - positions[index].position), 0.2f);
        }

        if (Vector3.Distance(positions[index].position, transform.position) == 0)
        {
            index++;
        }
    }
}
