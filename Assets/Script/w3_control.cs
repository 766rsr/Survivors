using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w3_control : MonoBehaviour
{
    public GameObject w3_1,w3_2;
    public Vector3[] objectScale = new Vector3[2];
    // Start is called before the first frame update
    void Start()
    {
        transform.position = player_control.PlayerVec3;
        gameObject.transform.parent = GameObject.Find("player").transform;

        objectScale[0] = w3_1.transform.localScale;
        objectScale[1] = new Vector3(objectScale[0].x*2,  objectScale[0].y*2, objectScale[0].z*2);        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player_control.PlayerVec3;        
        if((Menu_basic.weapongetlevel[3]-1) > 0){
            transform.RotateAround(player_control.PlayerVec3, Vector3.up, 200 * Time.deltaTime * (Menu_basic.weapongetlevel[3]-1));
        }else{
            transform.RotateAround(player_control.PlayerVec3, Vector3.up, 200 * Time.deltaTime );
        }
        if(Menu_basic.weapongetlevel[3] > 1) w3_1.transform.localScale=objectScale[1]; else w3_1.transform.localScale=objectScale[0];
        if(Menu_basic.weapongetlevel[3] > 1) w3_2.transform.localScale=objectScale[1]; else w3_2.transform.localScale=objectScale[0];
    }
}
