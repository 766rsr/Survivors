using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_control : MonoBehaviour
{
    public static int type=0; //0 stop
    
    public Image bloodImg;
    public Image playerui;
    public Image scoreui;
    public static Vector3 PlayerVec3 = new Vector3(0f,2f,0f);

    public static float PlayerScore = 0;
    public static float PlayerMAXScore = 5;
    public static float PlayerLife = 0;
    public static float PlayerMaxLife  = 400;
    
    public static float PlayerMight = 3;
    public static float PlayerArmor = 1;
    public static float PlayerRecovery  = 0.05f;
    public static float PlayerCooldown  = 1.5f;
    public static float PlayerDuration = 1f;
    public static float PlayerMoveSpeed = 20f;
    public static float PlayerGrowth = 1;

    public float t;

    // Start is called before the first frame update
    void Start()
    {
        PlayerScore = 0;
        PlayerMAXScore = 5;
        PlayerLife = 0;
        PlayerMaxLife  = 400;        
        PlayerMight = 3;
        PlayerArmor = 1;
        PlayerRecovery  = 0.05f;
        PlayerCooldown  = 1.5f;
        PlayerDuration = 1f;
        PlayerMoveSpeed = 20f;
        PlayerGrowth = 1;
        
        PlayerLife=PlayerMaxLife;
        t=Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        bloodImg.fillAmount = PlayerLife/PlayerMaxLife;
        scoreui.fillAmount = PlayerScore/PlayerMAXScore;

        PlayerVec3 = transform.localPosition;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        transform.position += new Vector3(x,0,z) * PlayerMoveSpeed * Time.deltaTime;

        if(PlayerMAXScore<PlayerScore){            
            PlayerScore=PlayerScore-PlayerMAXScore;

            PlayerMight *= 1.05f;
            PlayerRecovery *= 1.05f;
            PlayerCooldown *= 0.96f;
            PlayerCooldown *= 1.05f;
            PlayerMAXScore *= 1.2f;
            PlayerGrowth *=1.1f;

            Menu_basic.GameIsLevelup = true;            
        }

        if(Time.time-t>1 && PlayerMaxLife-PlayerLife>0){
            t=Time.time;
            PlayerLife+=PlayerRecovery;
        }

        if(PlayerLife <= 0)  SceneManager.LoadScene("scene_menu");
    }
}
