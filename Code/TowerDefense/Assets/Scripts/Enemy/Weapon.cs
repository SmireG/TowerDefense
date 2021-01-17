using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float attack = 20.0f;
    public float speed = 5.0f;
    public Transform target;
    private float distanceToTarget;   //两者之间的距离
    public GameObject explosion;    // Start is called before the first frame update


    public void setTarget(Transform target)
    {
        this.target = target;
        distanceToTarget = Vector3.Distance(this.transform.position, target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        else { 
        Vector3 targetPos = target.transform.position;

        //让始终它朝着目标
        transform.LookAt(targetPos);

        //计算弧线中的夹角
        float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * 45;
        transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
        float currentDist = Vector3.Distance(this.transform.position, target.transform.position);
        if (currentDist <5f)
            Die();
        transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
       }
    }

    private void Die()
    {
       

        target.GetComponent<Turret>().TakeDamage(attack);
        Destroy(gameObject);

    }
    
}
