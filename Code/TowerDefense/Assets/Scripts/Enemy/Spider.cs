using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{

    public List<GameObject> targets = new List<GameObject>();
    public float attack = 20.0f;
    public GameObject boomAnim;



    public override void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (hp <= 0) return;
        UpdatePlayers();
        canvas.transform.rotation = mainCamera.transform.rotation;
        Move();
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
        TechManage.TechPoints += 1;

        for (int index = 0; index < targets.Count; index++)
        {
            if (targets[index] == null) return;
            targets[index].GetComponent<Turret>().TakeDamage(attack);
        
        }
        GameObject tmpAnmi= Instantiate(boomAnim, this.transform);
        Destroy(tmpAnmi, 2f);
        characterAnimator.SetBool("isDead", true);
        Destroy(gameObject, 2.5f);
    }
}
