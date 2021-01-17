using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;
public class CSBuff : MonoBehaviour
{
    public GameObject[] nextbuttons;

    public Text info;


    TechManage techManage;
    bool flag = true;
    int index = 0;
    private Renderer renderer;
    private Color initColor;
    //Start is called before the first frame update
    public Text techText;

    public void ChangeTech(string m)
    {
        Debug.Log(techText == null);
        if (techText != null) techText.text = "$ " + TechManage.TechPoints;
        info.text = m;
    }
    void Start()
    {
        if (TechManage.CS3)
        {
            this.GetComponent<Button>().interactable = false;
            this.GetComponent<CSGUI>().interactable = false;
            for (int j = 0; j < nextbuttons.Length; j++)
            {
                // Debug.Log(j);
                nextbuttons[j].SetActive(true);
                //Debug.DrawLine(transform.position, nextbuttons[j].transform.position, Color.yellow);





                // Graphics.DrawMesh(mesh,)
            }

        }
        //techManage = TechManage.getInstance();
        renderer = GetComponent<Renderer>();
        //initColor = renderer.material.color;

        this.GetComponent<Button>().onClick.AddListener(OnClick);


        /*if (flag)
        {
            TechManage.setHPBoost(0.2f);

            flag = false;
        }*/

    }
    public void OnMouseEnter()
    {
        //this.GetComponent<Button>().enabled = false;    
        //this.GetComponent<Button>().interactable = false;    
        //Debug.Log("Cock");
        //renderer.material.color = Color.red;

        //if (EventSystem.current.IsPointerOverGameObject() == false)
        // {
        //  renderer.material.color = Color.red;
        //}
    }

    void OnClick()
    {

        

        Image i = this.GetComponent<Image>();
        i = null;
        //renderer.material.color = Color.red;

        // transform.GetChild

        Debug.Log("3");
        // TechManage.setHPBoost(200f);

        
        //UnityEditor.EditorUtility.DisplayDialog("", " ", "OK", "Cancel");

        if (TechManage.TechPoints < 50)
        {
            ChangeTech("Failed to get the degree because your Tech points are not enough");
        }
        else
        {
            TechManage.TechPoints -= 50;
            String m= "Congratulations! " +
                "You now have a CS phd degree."+ "Now Tang Bo, the master of DSAA is angry with the litchee stealers, " +
                "and vowed to use his DSAA quiz to scare the shit away the small animals and people at a probability of 10%.";
            ChangeTech(m);
            TechManage.CS3 = true;
           

            TechManage.SpeedBoost = TechManage.SpeedBoost * 1.5f;

            TechManage.theAngerOfTangBo = true;

            TechManage.majorFlag = true;
            // this.GetComponent<Button>().enabled = false;


            this.GetComponent<Button>().interactable = false;


            // if(nextbutton!=null)nextbutton.SetActive(true);

            for (int j = 0; j < nextbuttons.Length; j++)
            {
                nextbuttons[j].SetActive(true);
            }

            if (index <= 1)
            {
                //TechManage.CSbuttons[index + 1].SetActive(true);

            }
        }

        //this.GetComponent<Button>().SetActive;
        //  UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
    }
    void OnMouseExit()
    {
        // renderer.material.color = initColor;
    }
    // Update is ca lled once per frame
    void Update()
    {

    }
}
