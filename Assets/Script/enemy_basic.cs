using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_basic : MonoBehaviour
{
    public GameObject exp;
    public GameObject HitVFX;
    public float EnemyLife = 3;
    public float EnemySpeed = 10f;
    public int Enemytype=0;
    public float t;


    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(player_control.PlayerVec3);
        t=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemytype==0) transform.LookAt(player_control.PlayerVec3);
        transform.Translate(0,0,EnemySpeed * Time.deltaTime);

        if(EnemyLife<=0){
            GameObject.Find("player").SendMessage("audio_bomb");
            Instantiate(exp,transform.position, transform.rotation);
            Instantiate(HitVFX,transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
    
    void OnTriggerStay(Collider otherObject)
    {  
        if(otherObject.name == "w0(Clone)") EnemyLife -= player_weapon.weapon_damage[0];
        if(otherObject.name == "w1(Clone)") EnemyLife -= player_weapon.weapon_damage[1];
        
        if(otherObject.name == "player") player_control.PlayerLife -= (4 - player_control.PlayerArmor);        
    }
    
    void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.name == "w2(Clone)") {
            Destroy(otherObject.gameObject);
            EnemyLife -= player_weapon.weapon_damage[2];
        }
        
        if(otherObject.name == "w3 (1)") {
            EnemyLife -= player_weapon.weapon_damage[3];
        }
        if(otherObject.name == "w3 (2)") {
            EnemyLife -= player_weapon.weapon_damage[3];
        }

        if(otherObject.name == "Cube (1)") {
            EnemyLife -= player_weapon.weapon_damage[4];
        }
        if(otherObject.name == "Cube (2)") {
            EnemyLife -= player_weapon.weapon_damage[4];
        }

        if(otherObject.name == "boundup") Destroy(this.gameObject);
        if(otherObject.name == "bounddown") Destroy(this.gameObject);
        if(otherObject.name == "boundleft") Destroy(this.gameObject);
        if(otherObject.name == "boundright") Destroy(this.gameObject);
    }
}
