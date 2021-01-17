using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject acidPanel = null;
    private GameObject firePanel = null;
    private GameObject gatlingPanel = null;
    private GameObject mortarPanel = null;
    private GameObject radarPanel = null;
    private bool gat = false;
    private bool acid = false;
    private bool fire = false;
    private bool mortar = false;
    private bool radar = false;
    void Start()
    {
        acidPanel = transform.Find("Acid").gameObject;
        firePanel = transform.Find("Fire").gameObject;
        gatlingPanel = transform.Find("Gatling").gameObject;
        mortarPanel = transform.Find("Mortar").gameObject;
        radarPanel = transform.Find("Radar").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (gat == false)
            {
                Showinfo(gatlingPanel);
                gat = true;
            }
            else
            {
                Hideinfo(gatlingPanel);
                gat = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (acid == false)
            {
                Showinfo(acidPanel);
                acid = true;
            }
            else
            {
                Hideinfo(acidPanel);
                acid = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (fire == false)
            {
                Showinfo(firePanel);
                fire = true;
            }
            else
            {
                Hideinfo(firePanel);
                fire = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (mortar == false)
            {
                Showinfo(mortarPanel);
                mortar = true;
            }
            else
            {
                Hideinfo(mortarPanel);
                mortar = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (radar == false)
            {
                Showinfo(radarPanel);
                radar = true;
            }
            else
            {
                Hideinfo(radarPanel);
                radar = false;
            }
        }
    }
    private void Showinfo(GameObject canv)
    {
        Hideinfo(acidPanel);
        acid = false;
        Hideinfo(firePanel);
        fire = false;
        Hideinfo(gatlingPanel);
        gat = false;
        Hideinfo(mortarPanel);
        mortar = false;
        Hideinfo(radarPanel);
        radar = false;
        canv.SetActive(true);
    }
    private void Hideinfo(GameObject canv)
    {
        canv.SetActive(false);
    }
}
