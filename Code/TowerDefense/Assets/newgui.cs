using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newgui : Button
{



    enum Selection
    {
        Normal,
        Highlighted,
        Pressed,
        Disabled
    }
    Selection selection;

    private void OnGUI()
    {
        GUI.skin.box.fontSize = 10;
        switch (selection)
        {
            case Selection.Highlighted:
                GUI.Box(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 25), "Computer Science");


                break;
            case Selection.Pressed:
                GUI.Box(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 25), "Pressed");
                Color a = transform.GetComponent<SpriteRenderer>().color;
                a.a = 0.5f;
                this.interactable = false;
                transform.GetComponent<SpriteRenderer>().color = a;

                // transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
                break;
            default:
                break;
        }
    }
    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);
        switch (state)
        {
            //四种状态
            case SelectionState.Normal:
                selection = Selection.Normal;
                break;
            case SelectionState.Highlighted:
                selection = Selection.Highlighted;

                break;
            case SelectionState.Pressed:
                selection = Selection.Pressed;

                break;
            case SelectionState.Disabled:
                selection = Selection.Disabled;
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
