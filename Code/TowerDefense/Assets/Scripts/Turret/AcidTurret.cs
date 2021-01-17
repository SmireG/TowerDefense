using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidTurret : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
         //  col.gameObject.GetComponent<Enemy>().speed = col.gameObject.GetComponent<Enemy>().speed * speeddate;
           enemys.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
          //  col.gameObject.GetComponent<Enemy>().speed = col.gameObject.GetComponent<Enemy>().speed / speeddate;
            enemys.Remove(col.gameObject);
        }
    }
    // Start is called before the first frame update


    // Update is called once per frame
    public float speeddate = 0.8f;
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
        if (enemys.Count > 0 && timer >= attackrate)
        {
            timer = 0;
            attack();
        }

    }
    void attack()
    {
        attackrate= 1f/TechManage.SpeedBoost;
        if (enemys[0] == null)
        {
            Updateenemy();
        }
        if (enemys.Count > 0)
        {
            GameObject.Instantiate(bullet, fireposition.position, fireposition.rotation);
            bullet.GetComponent<Bullet>().setTarget(enemys[0]);
            if (!enemys[0].GetComponent<Enemy>().isSlowed)
            {
                enemys[0].GetComponent<Enemy>().speed = enemys[0].GetComponent<Enemy>().speed * speeddate/TechManage.AcidBoost;
                enemys[0].GetComponent<Enemy>().isSlowed = true;
            }
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
