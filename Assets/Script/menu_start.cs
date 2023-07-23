using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_start : MonoBehaviour
{
    public GameObject MenuStart;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        MenuStart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame(){        
        SceneManager.LoadScene("scene_game");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
