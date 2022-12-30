using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager CanvasInstance;
    public bool state;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        state=false;
        CanvasInstance=this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SGame(){
        state=true;// boolean to check if press or not
        menu.SetActive(false);//make panel dispaire when play or tap for play
    }
     public void clickBtn(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
