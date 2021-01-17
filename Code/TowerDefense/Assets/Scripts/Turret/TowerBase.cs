using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TowerBase : MonoBehaviour
{
    public GameObject turretGo = null;//保存当前cube身上的炮台
    public Turret turret = new Turret();
    public bool isUpgraded = false;
    private Renderer renderer;
    private Color initialColor;
    public string label;
    // Start is called before the first frame update
    void Start()
    {

        renderer = GetComponent<Renderer>();
        initialColor = renderer.material.color;
    }
    void Update()
    {
    }

    public void BuildTurret(Turret turret)
    {
        this.turret = turret;
        isUpgraded = false;
        Vector3 temp = new Vector3(transform.position.x, transform.position.y+5, transform.position.z);
        turretGo = Instantiate(turret.turretprefab, temp, Quaternion.identity);
        label = turret.label;
    }
    void OnMouseEnter()
    {

        if (turretGo == null && EventSystem.current.IsPointerOverGameObject() == false)
        {
            renderer.material.color = Color.red;
        }
    }
    void OnMouseExit()
    {
        renderer.material.color = initialColor;
    }
}
