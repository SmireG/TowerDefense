using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class TechManage : MonoBehaviour
{

    public static bool ini = false;
    public static bool CS1 = false;
    public static bool CS2 = false;
    public static bool CS3 = false;

    public static bool FI1 = false;
    public static bool FI2 = false;
    public static bool FI3 = false;
    
    public static bool Me1 = false;
    public static bool Me2 = false;
    public static bool Me3 = false;

    public static bool Che1 = false;
    public static bool Che2 = false;
    public static bool Che3 = false;

    public static bool EE1= false;
    public static bool EE2 = false;
    public static bool EE3= false;






    static float HPBoost=1f;

    public static bool majorFlag = false;
    public  List<Button> CSbuttons;
    public  List<Button> Medbuttons;
    public List<Button> Fibuttons;
    public  List<Button> Mebuttons;
    public List<Button> ChButtons;
    public static float AttackBoost=1f;
    public static float AcidBoost = 1f;
    public static float SpeedBoost = 1f;
    public static float MoneyBoost = 1f;
    public static bool rebirth = false;
    public static bool theAngerOfTangBo = false;
    public static bool freeTrade = false;


    public Text techText;
    public static int TechPoints = 1000;
    public static float timer = 1.0f;
    public static Animator TechAnimator;
    public static int CSCounter=0;

    public static bool isChange = false;

    //private static TechManage techManage = new TechManage();


    public void ChangeTech(int change)
    {
        TechPoints += change;
        Debug.Log(techText==null);
        if(techText!=null)techText.text = "$ " + TechPoints;
    }

   

    public static TechManage getInstance()
    {
       return null;
    }

    //public static GameObject[] getit()
    //{
        
      //  return TechManage.CSbuttons;
    //}

   public static float getHPBoost()
  {
       // while (Random.Range(0, 100) <= 20)
        //{
            // 让某件事发生的概率是百分之二十,我怎么就没想到呢
        //}
        return HPBoost;
    }
    public static void setHPBoost(float a)
    {
        HPBoost=a*HPBoost;
        Debug.Log(HPBoost);
    }
    public static float getAttackBoost()
    {
        float instantKillFactor = 1f;
        if (theAngerOfTangBo)
        {
            if (Random.Range(0, 100) <= 60)
            {
                instantKillFactor = 100000;
            }
        }
        return AttackBoost*instantKillFactor;
    }

    public static int Gen_random()
    {
        return Random.Range(0, 100);
    }
    public static float getDiscount()
    {
        float di = 100;
        if(freeTrade)
            di=(float)Random.Range(70, 100);
        return di / 100f;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

  /*  void Awake()
    {
        int n = gameObject.childCount;
        CSbuttons = new GameObject[n];

        int i = 0;
        while (i < n)
        {
            positions[i] = transform.GetChild(i);
            i++;

        }

    }
  */


    // Update is called once per frame
    void Update()
    {
       
        
     
    }
}
