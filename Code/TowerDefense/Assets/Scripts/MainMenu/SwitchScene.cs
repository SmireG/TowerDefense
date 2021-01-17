using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    // Use this for initialization
    public void switchIniti()
    {
        SceneManager.LoadScene("InitScene");
    }
    public void switchSelect()
    {
        SceneManager.LoadScene("SelectScene");
    }
    public void switchTech()
    {
        SceneManager.LoadScene("TechScene");
    }
    public void switchTB()
    {
        SceneManager.LoadScene("TeachingBuilding");
    }
    public void switchLake()
    {
        SceneManager.LoadScene("Lake");
    }
    public void switchLH()
    {
        SceneManager.LoadScene("LycheeHill");
    }
    public void switchJoy()
    {
        SceneManager.LoadScene("JoyHighLand");
    }
    public void exit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }


}