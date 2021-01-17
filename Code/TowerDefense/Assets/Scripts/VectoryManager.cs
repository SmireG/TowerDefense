using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VectoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string next; 
    void Start()
    {
        
    }
    public void switchNext()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(next);
    }
    public void switchBack()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("InitScene");
    }
}
