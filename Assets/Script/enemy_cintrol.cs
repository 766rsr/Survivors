using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_cintrol : MonoBehaviour
{
    public static float timestart=0;
    public GameObject[] enemy = new  GameObject[10];
    public double[] t = new double[20];

    public int interval=20;
    // Start is called before the first frame update
    void Start()
    {
        timestart = Time.time;
        for(int i=0;i<20;i++){
            t[i]=Time.time+(i/4)*interval;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<20;i++){
            if(Time.time>t[i]){
                if(i/4 <= 3){
                    t[i]=Time.time+UnityEngine.Random.Range(0,Time.time-timestart-interval*(i/4))*0.01+2+(Time.time-timestart-interval*(i/4))*0.02;
                }else{
                    t[i]=Time.time+UnityEngine.Random.Range(0,Time.time-timestart-interval*(i/4))*0.01;
                    if(2-(Time.time-timestart-interval*(i/4))*0.05 > 0) t[i] += 2-(Time.time-timestart-interval*(i/4))*0.05;
                }
                if(i%4 == 0) creat((i/4)+1,UnityEngine.Random.Range(-46,46),27f);
                if(i%4 == 1) creat((i/4)+1,UnityEngine.Random.Range(-46,46),-27f);
                if(i%4 == 2) creat((i/4)+1,46,UnityEngine.Random.Range(-27,27));
                if(i%4 == 3) creat((i/4)+1,-46,UnityEngine.Random.Range(-27,27));
            }
        }
    }

    void creat(int type ,float fx , float fz){
        Instantiate(enemy[type],player_control.PlayerVec3+new Vector3(fx,0,fz), transform.rotation);
    }
}
