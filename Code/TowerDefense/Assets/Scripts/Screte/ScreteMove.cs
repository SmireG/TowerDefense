using UnityEngine;

public class ScreteMove : MonoBehaviour
{
    private Animator Animator;
    public float timer = 10.0f;
    private bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        Animator = transform.GetChild(0).GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 10.0f;
            Animator.SetBool("isMoving", flag);
            flag = !flag;
        }
    }
    

}
