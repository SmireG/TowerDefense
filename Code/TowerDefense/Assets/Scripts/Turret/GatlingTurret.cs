using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingTurret : MonoBehaviour
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
    public GameObject head;
    void Start()
    {
        head = transform.GetChild(1).gameObject;
        timer = attackrate;
    }

    void Update()
    {
        UpdateEnemy();
        if (enemys.Count > 0 && enemys[0] != null)
        {
            //Vector3 targetpos = enemys[0].transform.position;
            //targetpos.y = enemys[0].transform.position.y;
            head.transform.rotation = Quaternion.Slerp(head.transform.rotation, Quaternion.LookRotation(enemys[0].transform.position - head.transform.position), 100f);

           // head.transform.LookAt(enemys[0].transform.position);
        }
        timer = timer + Time.deltaTime;
        if (enemys.Count > 0 && timer >= attackrate) {
            timer=0;
            Attack();
        }
        
    }
    void Attack() {
        attackrate = 1f/ attackrate;

        if (enemys.Count > 0)
        {
            int index = 0;
            float dis = (transform.position - enemys[0].transform.position).sqrMagnitude;

            for (int i = 1; i < enemys.Count; i++)
            {
                if ((transform.position - enemys[i].transform.position).sqrMagnitude < dis)
                {
                    index = i;
                    dis = (transform.position - enemys[i].transform.position).sqrMagnitude;
                }
            }


            Instantiate(bullet, fireposition.position, fireposition.rotation);
            bullet.GetComponent<Bullet>().setTarget(enemys[index]);
        }
        else {
            timer = attackrate;
        }
    }
    void UpdateEnemy() {
        List<int> empty = new List<int>();
        for (int i = 0; i < enemys.Count; i++) {
            if (enemys[i] == null)
            {
                empty.Add(i);
            }
        }
        for (int i = 0; i < empty.Count; i++)
        {
            enemys.RemoveAt(empty[i]-i);
        }
    }

}
