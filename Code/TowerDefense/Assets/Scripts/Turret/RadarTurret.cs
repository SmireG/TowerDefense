using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarTurret : MonoBehaviour
{
    public List<GameObject> towers = new List<GameObject>();
    public float hpdate;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "TowerBase")
        {
            if (col.gameObject.GetComponent<TowerBase>().turretGo != null)
            {
                col.gameObject.GetComponent<TowerBase>().turret.hp = col.gameObject.GetComponent<TowerBase>().turret.hp*hpdate;
                towers.Add(col.gameObject);
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "TowerBase")
        {

            towers.Remove(col.gameObject);
        }
    }
    // Start is called before the first frame update


    // Update is called once per frame


}
