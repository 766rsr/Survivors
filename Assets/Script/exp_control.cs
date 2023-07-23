using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class exp_control : MonoBehaviour
{
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        t=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - t >30) Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider otherObject){
        if(otherObject.name == "player"){
            GameObject.Find("player").SendMessage("audio_eat");
            player_control.PlayerScore = player_control.PlayerScore + player_control.PlayerGrowth;
            Destroy(this.gameObject);
        }
    }
}
