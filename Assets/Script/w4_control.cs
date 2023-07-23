using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w4_control : MonoBehaviour
{
    public GameObject cu1,cu2;
    public Vector3[] objectScalew4 = new Vector3[3];
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        t=Time.time;
        transform.position = player_control.PlayerVec3;
        gameObject.transform.parent = GameObject.Find("player").transform;

        objectScalew4[0] = cu1.transform.localScale;
        objectScalew4[1] = new Vector3(objectScalew4[0].x*2,  objectScalew4[0].y*2, objectScalew4[0].z*3);        
        objectScalew4[2] = new Vector3(objectScalew4[0].x*3,  objectScalew4[0].y*3, objectScalew4[0].z*5);    

        if(Menu_basic.weapongetlevel[4] == 2){
            cu1.transform.localScale=objectScalew4[1];
            cu2.transform.localScale=objectScalew4[1];
        }
        
        if(Menu_basic.weapongetlevel[4] > 2){
            cu1.transform.localScale=objectScalew4[2];
            cu2.transform.localScale=objectScalew4[2];
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - t > 0.1) Destroy(this.gameObject);
    }
}
