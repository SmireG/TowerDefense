using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class ini : MonoBehaviour
{
    public GameObject[] nextbuttons;

    public GameObject lines;

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
        if (TechManage.ini)
        {
            this.GetComponent<Button>().interactable = false;
            this.GetComponent<MainGUI>().interactable = false;
            for (int j = 0; j < nextbuttons.Length; j++)
            {
                // Debug.Log(j);
                nextbuttons[j].SetActive(true);
                //Debug.DrawLine(transform.position, nextbuttons[j].transform.position, Color.yellow);
                lines.SetActive(true);




                // Graphics.DrawMesh(mesh,)
            }

        }


        ChangeTech();

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

        Debug.Log("3");
        //TechManage.setHPBoost(200f);
        TechManage.majorFlag = true;
        m = "Congratulations, you are admitted to SUSTech";
        ChangeTech();
        // this.GetComponent<Button>().enabled = false;

        TechManage.ini = true;

        this.GetComponent<Button>().interactable = false;


        // if(nextbutton!=null)nextbutton.SetActive(true);

        for (int j = 0; j < nextbuttons.Length; j++)
        {
            Debug.Log(j);
            nextbuttons[j].SetActive(true);
            Debug.DrawLine(transform.position, nextbuttons[j].transform.position, Color.yellow);
            lines.SetActive(true);




           // Graphics.DrawMesh(mesh,)
        }

        if (index <= 1)
        {
            //TechManage.CSbuttons[index + 1].SetActive(true);

        }

        //this.GetComponent<Button>().SetActive;
        //  UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
    }
    void OnMouseExit()
    {
        // renderer.material.color = initColor;
    }

    //void DrawLine(Vector3 v1,Vector3 v2)
    //{
        //GL.
    //}



    // Update is ca lled once per frame
    void Update()
    {

    }
}
