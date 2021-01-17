using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class FIBBuff : MonoBehaviour
{
    public GameObject[] nextbuttons;




    TechManage techManage;
    bool flag = true;
    int index = 0;
    private Renderer renderer;
    private Color initColor;
    //Start is called before the first frame update
    public Text techText;
    public Text info;
    private string m;
    public void ChangeTech()
    {
        Debug.Log(techText == null);
        if (techText != null) techText.text = "$ " + TechManage.TechPoints;
        info.text = m;
    }
    void Start()
    {

        if (TechManage.FI3)
        {
            this.GetComponent<Button>().interactable = false;
            this.GetComponent<FIGUI>().interactable = false;
            for (int j = 0; j < nextbuttons.Length; j++)
            {
                // Debug.Log(j);
                nextbuttons[j].SetActive(true);
                //Debug.DrawLine(transform.position, nextbuttons[j].transform.position, Color.yellow);





                // Graphics.DrawMesh(mesh,)
            }

        }
        techManage = TechManage.getInstance();
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


        if (TechManage.TechPoints < 50)
        {
            m = "Failed to get the degree because your Tech points are not enough";
            ChangeTech();
        }
        else
        {
            TechManage.FI3 = true;
            TechManage.TechPoints -= 50;
            m= "Congratulations! You now have a Financial phd degree.Now you used your financial expertise to help China reach a free trade treaty with other nations, all your turret will be discounted by a random number from 1 percent to 30 percent.";

            ChangeTech();


            TechManage.freeTrade = true;

            Debug.Log("3");
            TechManage.MoneyBoost *=1.5f;
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
