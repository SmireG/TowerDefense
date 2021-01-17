using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManage : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 init;
    void Start()
    {
        init = this.GetComponent<RectTransform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        bool isUI = RectTransformUtility.RectangleContainsScreenPoint(this.GetComponent<RectTransform>(), Input.mousePosition);
        if (isUI)
        {
            //this.GetComponent<RectTransform>().sizeDelta = 2 * init -init / 2 ;
            this.GetComponent<RectTransform>().localScale = init * 2 - init / 2;
        }
        else
        {

            //this.GetComponent<RectTransform>().sizeDelta = init;
            this.GetComponent<RectTransform>().localScale = init;
        }
    }

}
