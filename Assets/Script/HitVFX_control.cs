using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitVFX_control : MonoBehaviour
{
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        t=Time.time;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - t >1) Destroy(this.gameObject);
    }
}
