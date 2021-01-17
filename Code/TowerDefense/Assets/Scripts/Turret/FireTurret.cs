using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTurret : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemys.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemys.Remove(col.gameObject);
        }
    }
    // Start is called before the first frame update


    // Update is called once per frame

    public float attackrate = 1f;
    private float timer = 0;
    public GameObject bullet;
    public Transform fireposition;
    public Transform head;
    void Start()
    {
        timer = attackrate;
    }

    void Update()
    {

        if (enemys.Count > 0 && enemys[0] != null)
        {
            Vector3 targetpos = enemys[0].transform.position;
            targetpos.y = enemys[0].transform.position.y;
            head.LookAt(targetpos);
        }
        timer = timer + Time.deltaTime;
        if (enemys.Count >0 && timer >= attackrate)
        {
            timer = 0;
            attack();
        }

    }
    void attack()
    {
        attackrate = 1f / TechManage.SpeedBoost;
        if (enemys[0] == null)
        {
            Updateenemy();
        }
        else if (enemys.Count > 1)
        {
            GameObject.Instantiate(bullet, fireposition.position, fireposition.rotation);

            bullet.GetComponent<Bullet>().setTarget(enemys[0]);

            GameObject.Instantiate(bullet, fireposition.position, fireposition.rotation);

            bullet.GetComponent<Bullet>().setTarget(enemys[1]);

        }
        else if (enemys.Count > 0)
        {
            GameObject.Instantiate(bullet, fireposition.position, fireposition.rotation);

            bullet.GetComponent<Bullet>().setTarget(enemys[0]);

        }
        else
        {
            timer = attackrate;
        }
    }
    void Updateenemy()
    {
        List<int> empty = new List<int>();
        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] == null)
            {
                empty.Add(i);
            }
        }
        for (int i = 0; i < empty.Count; i++)
        {
            enemys.RemoveAt(empty[i] - i);
        }
    }
   
}
