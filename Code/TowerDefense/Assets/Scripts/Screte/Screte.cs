using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screte : MonoBehaviour
{
    public GameObject scretePanel = null;
    RaycastHit hit = new RaycastHit();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("GetMouse");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.transform.tag == "Screte")
                {
                    Debug.Log("GetScrete");
                    scretePanel.SetActive(true);
                }
            }
        }
    }
    public void OnClickOk()
    {
        scretePanel.SetActive(false);
    }
}
