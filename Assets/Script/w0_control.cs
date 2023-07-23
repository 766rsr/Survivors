using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w0_control : MonoBehaviour
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
        if(Time.time-t>player_control.PlayerDuration*Menu_basic.w0Cooldown) Destroy(this.gameObject);
    }
}
