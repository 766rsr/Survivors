using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w1_control : MonoBehaviour
{
    public Vector3[] objectScale = new Vector3[2];
    // Start is called before the first frame update
    void Start()
    {
        transform.position = player_control.PlayerVec3;
        gameObject.transform.parent = GameObject.Find("player").transform;

        objectScale[0] = transform.localScale;
        objectScale[1] = new Vector3(objectScale[0].x*2,  objectScale[0].y*2, objectScale[0].z*2);

        //gameObject.transform.GetChild(int index).gameObject; 取得子物件
    }

    // Update is called once per frame
    void Update()
    {
        if(Menu_basic.weapongetlevel[1] > 1) transform.localScale=objectScale[1]; else transform.localScale=objectScale[0];
    }
}
