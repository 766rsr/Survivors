using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_weapon : MonoBehaviour
{
    public GameObject[] weapon = new GameObject[10];
    public static float[] weapon_control = new float[10];
    public static int[] weapon_switch = new int[10];
    public static float[] weapon_damage = new float[10];
    public double t;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<10;i++){
            weapon_control[i]=0;
        }
        t=Time.time;

        //Menu_basic.weapongetlevel[1]=1;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<5;i++){
            if(Menu_basic.weapongetlevel[i] != weapon_control[i]){                
                weapon_control[i] = Menu_basic.weapongetlevel[i];

                if(i==1 && Menu_basic.weapongetlevel[i] == 1) Instantiate(weapon[1],player_control.PlayerVec3, transform.rotation);
                if(i==3 && Menu_basic.weapongetlevel[i] == 1) Instantiate(weapon[3],player_control.PlayerVec3, transform.rotation);
            }
        }

        
        if(Time.time > t){
            t=Time.time + player_control.PlayerCooldown;            
            //w0            
            if(Menu_basic.weapongetlevel[0]>0){
                for(int i=0;i<Menu_basic.weapongetlevel[0];i++){
                    if(i>=3) break;
                    Instantiate(weapon[0],player_control.PlayerVec3+new Vector3(UnityEngine.Random.Range(-15,15),0,UnityEngine.Random.Range(-15,15)), transform.rotation);
                }    
            }

            //w2
            if(Menu_basic.weapongetlevel[2]>0){
                GameObject.Find("player").SendMessage("audio_shoot");
                for(int i=0;i<Mathf.Pow(2,Menu_basic.weapongetlevel[2]);i++){
                    
                    Instantiate(weapon[2],player_control.PlayerVec3, transform.rotation);
                }
            }

            //w4
            if(Menu_basic.weapongetlevel[4]>0){
                GameObject.Find("player").SendMessage("audio_laser");
                Instantiate(weapon[4],player_control.PlayerVec3, transform.rotation);
            }   
        }
        
    }
}
