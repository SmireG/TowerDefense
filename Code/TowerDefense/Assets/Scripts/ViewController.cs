using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public float panSpeed = 10;
    public float scrollSpeed = 2500;
    private float initialMousePosX;
    private float initialMousePosY;

    private float initialRotX;
    private float initialRotY;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 89)
            {
                Camera.main.fieldOfView += 1;
            }
        }


        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView >= 0)
            {
                Camera.main.fieldOfView -= 1;
            }
        }

        Quaternion direction = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        if (Input.GetButton("Horizontal"))
        {
            Vector3 dir = transform.InverseTransformDirection(direction * Vector3.right);
            transform.Translate(dir * panSpeed * 0.1f * Input.GetAxisRaw("Horizontal"));
        }

        if (Input.GetButton("Vertical"))
        {
            Vector3 dir = transform.InverseTransformDirection(direction * Vector3.forward);
            transform.Translate(dir * panSpeed * 0.1f * Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetMouseButtonDown(1))
        {
            initialMousePosX = Input.mousePosition.x;
            initialMousePosY = Input.mousePosition.y;
            initialRotX = transform.eulerAngles.y;
            initialRotY = transform.eulerAngles.x;
        }

        if (Input.GetMouseButton(1))
        {
            float deltaX = Input.mousePosition.x - initialMousePosX;
            float deltaRotX = (.1f * (initialRotX / Screen.width));

            float x = .1f * deltaX + deltaRotX + initialRotX;

            float deltaY = initialMousePosY - Input.mousePosition.y;
            float deltaRotY = -(.1f * (initialRotY / Screen.height));

            float y = .1f * deltaY + deltaRotY + initialRotY;



            transform.rotation = Quaternion.Euler(y, x, 0);
        }

    }
}
