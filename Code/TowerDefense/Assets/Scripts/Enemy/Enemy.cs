using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[Serializable]
public class Enemy : MonoBehaviour
{
    public float speed = 50;
    public float hp = 15;
    public bool isSlowed = false;
    protected float totalHp;
    protected Slider hpSlider;
    protected Transform[] positions;
    protected Animator characterAnimator;
    protected int index = 0;
    protected GameObject mainCamera;
    protected Canvas canvas;
    protected Color initialColor;
    protected Renderer enemyRenderer;


    public void SetPosition(GameObject position)
    {
        int n = position.transform.childCount;
        positions = new Transform[n];
        int i = 0;
        while (i < n)
        {
            positions[i] = position.transform.GetChild(i);
            i++;

        } 
    }


    // Start is called before the first frame update
    public virtual void Start()
    {
      
        totalHp = hp;
        hpSlider = GetComponentInChildren<Slider>();
        canvas = GetComponentInChildren<Canvas>();
        transform.forward = positions[0].position - transform.position;
        mainCamera = GameObject.FindWithTag("MainCamera");
        characterAnimator = transform.GetChild(0).GetComponent<Animator>();
        enemyRenderer = transform.GetChild(0).GetComponent<Renderer>();

    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        canvas.transform.rotation = mainCamera.transform.rotation;
        if (hp <= 0) return;
        Move();

    }

    public virtual void Move()
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
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(positions[index + 1].position - positions[index].position), 0.06f);
        }

        if (Vector3.Distance(positions[index].position, transform.position) == 0)
        {
            index++;
        }
    }




    public void TakeDamage(float damage)
    {

        
        hp -= damage;
        hpSlider.value = hp / totalHp;
        if (hp <= 0) {
            Die();
        }
    }

    public virtual void Die()
    {
        TechManage.TechPoints+=1;

        Destroy(gameObject);
    }

    public virtual void  OnDestroy()
    {
        GameManage.nowEnemyNumber++;
        GameManage.IsEnd(GameManage.nowEnemyNumber);
    }
}
