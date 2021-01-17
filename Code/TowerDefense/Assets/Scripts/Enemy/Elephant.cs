using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elephant : Enemy
{

    public GameObject bomb;
    public List<GameObject> targets = new List<GameObject>();
    private float timer = 2f;
    private float attackSpeed = 2f;



    public override void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (hp <= 0) return;
        timer += Time.deltaTime;
        UpdatePlayers();
        canvas.transform.rotation = mainCamera.transform.rotation;

        if (timer > attackSpeed)
        {
            characterAnimator.SetBool("isAttacking", true);
            timer -= attackSpeed;
            Attack();
        }
        if (!characterAnimator.GetBool("isAttacking"))
        {
            Move();
        }


    }

    void Attack()
    {
        if (targets.Count == 0)
        {
            characterAnimator.SetBool("isAttacking", false);
            return;
        }
        GameObject weapon = Instantiate(bomb, new Vector3(transform.position.x + -1.25f, transform.position.y + 1.47f, transform.position.z - 0.89f), transform.rotation);


        weapon.GetComponent<Weapon>().setTarget(targets[0].transform);
    }

    void UpdatePlayers()
    {
        List<int> emptyIndex = new List<int>();
        for (int index = 0; index < targets.Count; index++)
        {
            if (targets[index] == null)
            {
                emptyIndex.Add(index);
            }
        }

        for (int i = 0; i < emptyIndex.Count; i++)
        {
            targets.RemoveAt(emptyIndex[i] - i);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            targets.Add(collider.gameObject);
        }

    }
    private void OnTriggerExit(Collider collider)
    {
        //Debug.Log("OnTriggerExit");
        if (collider.tag == "Player")
        {
            targets.Remove(collider.gameObject);
        }
    }

    public override void Die()
    {
        TechManage.TechPoints += 10;

        characterAnimator.SetBool("isDead", true);
        Destroy(gameObject, 2.5f);
    }
}
