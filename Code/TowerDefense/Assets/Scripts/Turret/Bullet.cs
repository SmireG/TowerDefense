using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bullet : MonoBehaviour
{
    public int damage = 1;

    public int speed = 40;

    public Transform target;

    private Transform chidTarget;

    public void setTarget(GameObject _target) {
        target = _target.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    if (target == null) {
            Destroy(gameObject);
            return;
        }
        chidTarget = target.GetChild(0);

       
        transform.LookAt(chidTarget);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if ((transform.position - chidTarget.position).sqrMagnitude < 0.01f) {
            Die();
        }
    }

    void Die() {
        target.GetComponent<Enemy>().TakeDamage(damage*TechManage.getAttackBoost());
        Destroy(gameObject);
    }
}
