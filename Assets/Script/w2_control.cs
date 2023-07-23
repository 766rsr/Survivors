using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w2_control : MonoBehaviour
{
    public List<enemy_basic> ee;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        t=Time.time;
        transform.Rotate( 0,UnityEngine.Random.Range(0,360),0 );
    }

    // Update is called once per frame
    void Update()
    {
        ee = new List<enemy_basic>(FindObjectsOfType<enemy_basic>());
        float temp = Mathf.Infinity;
        Transform f=null;
        for(int i=0;i<ee.Count;i++){
            if(temp > Vector3.Distance(ee[i].transform.position,transform.localPosition)){
                temp=Vector3.Distance(ee[i].transform.position,transform.localPosition);
                f=ee[i].transform;
            }
        }
        if(f){
            if(Time.time-t > 0.3) transform.LookAt(f.position);
            transform.Translate(0,0,30 * Time.deltaTime);
        }
        if(Time.time-t > 1.5f) Destroy(this.gameObject);
    }
}
