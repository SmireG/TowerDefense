using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Turret: MonoBehaviour 
{
    public float hp =100f;
    public float totalHp = 100f;
    public GameObject turretprefab;
    private Slider hpSlider;
    private GameObject mainCamera;
    private Canvas canvas;
    public string label;
    void Start()
    {
        hp = hp * TechManage.getHPBoost();
        totalHp = hp;
        mainCamera = GameObject.FindWithTag("MainCamera");
        hpSlider = GetComponentInChildren<Slider>();
        canvas = GetComponentInChildren<Canvas>();
    }
    private void Update()
    {
        canvas.transform.rotation = mainCamera.transform.rotation;
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        
        hpSlider.value = (float)hp / totalHp;
        if (hpSlider.value <= 0.2f &&TechManage.rebirth)
        {
            int Ran = TechManage.Gen_random();
            //50% to reborn
            if (Ran <= 20)
            {
                hpSlider.value = 1.0f;
                hp = totalHp;
            }
        }
        if (hp <= 0) {
            
            GameManage.
            Destroy(gameObject);



        }
    }
}
