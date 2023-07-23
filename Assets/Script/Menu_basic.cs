using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_basic : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsLevelup = false;

    public GameObject pauseMenuUI;
    public GameObject MenuLevelup;
    public Text t1;
    public Text t2;
    public Text t3;
    public Text ttime;
    public Text tdata;

    public static int timecount;

    public static string [] weaponstring = new string [] {
        "<領域>","<領域>\n技能數量增加","<領域>\n技能數量增加","<領域>\n技能持續增加","<領域>\n技能持續增加","<領域>\n技能持續增加","基礎生命上限增加",
        "<立場>","<立場>\n技能範圍增加","<立場>\n技能傷害增加","<立場>\n技能傷害增加","<立場>\n技能傷害增加","<立場>\n技能傷害增加","基礎護甲增加",
        "<追蹤>","<追蹤>\n技能數量增加","<追蹤>\n技能數量增加","<追蹤>\n技能數量增加","<追蹤>\n技能數量增加","<追蹤>\n技能數量增加","基礎生命恢復增加",
        "<守衛>","<守衛>\n技能範圍增加","<守衛>\n技能速度增加","<守衛>\n技能速度增加","<守衛>\n技能速度增加","<守衛>\n技能速度增加","基礎技能冷卻增加",
        "<雷射>","<雷射>\n技能範圍增加","<雷射>\n技能範圍增加","<雷射>\n技能傷害增加","<雷射>\n技能傷害增加","<雷射>\n技能傷害增加","基礎移動速度增加",
        "基礎生命上限增加","基礎護甲增加","基礎生命恢復增加","基礎技能冷卻增加","基礎移動速度增加","基礎經驗取得增加"
    };

    public static int[] weapongetbefore = new int[]{0,1,2,3,4,5,6,7,8,9,10};
    public static int[] weapongetlevel = new int[]{0,0,0,0,0};

    //------------
    public static float w0Cooldown = 1;
    public int pp;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        MenuLevelup.SetActive(false);
        
        for(int i=0;i<5;i++) weapongetlevel[i] = 0;
        for(int i=0;i<11;i++) weapongetbefore[i] = i;

        for(int i=0;i<5;i++){
            int temp,x=UnityEngine.Random.Range(0,5);
            temp=weapongetbefore[x];
            weapongetbefore[x]=weapongetbefore[i];
            weapongetbefore[i]=temp;
        }
        if(weapongetbefore[0]>4) t1.text=weaponstring[weapongetbefore[0]+30]; else t1.text=weaponstring[weapongetbefore[0]*7+weapongetlevel[weapongetbefore[0]]];
        if(weapongetbefore[1]>4) t2.text=weaponstring[weapongetbefore[1]+30]; else t2.text=weaponstring[weapongetbefore[1]*7+weapongetlevel[weapongetbefore[1]]];
        if(weapongetbefore[2]>4) t3.text=weaponstring[weapongetbefore[2]+30]; else t3.text=weaponstring[weapongetbefore[2]*7+weapongetlevel[weapongetbefore[2]]];

        Time.timeScale = 0f;
        MenuLevelup.SetActive(true);
        
        pp=0;
    }

    // Update is called once per frame
    void Update()
    {
        ttime.text = "";
        timecount = (int)(Time.time - enemy_cintrol.timestart);
        int hr = timecount/60 , min = timecount%60;
        if(hr < 10) ttime.text = "0";        
        ttime.text = ttime.text + hr + " : ";
        if(min < 10) ttime.text = ttime.text + "0";
        ttime.text = ttime.text + min;
        
        if(Input.GetKeyDown(KeyCode.Escape) && !MenuLevelup.active){
            retdata();
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
        
        if(GameIsLevelup){
            GameIsLevelup = false;
            
            for(int i=0;i<11;i++){
                int temp,x=UnityEngine.Random.Range(0,11);
                temp=weapongetbefore[x];
                weapongetbefore[x]=weapongetbefore[i];
                weapongetbefore[i]=temp;
            }
            
            if(weapongetbefore[0]>4) t1.text=weaponstring[weapongetbefore[0]+30]; else t1.text=weaponstring[weapongetbefore[0]*7+weapongetlevel[weapongetbefore[0]]];
            if(weapongetbefore[1]>4) t2.text=weaponstring[weapongetbefore[1]+30]; else t2.text=weaponstring[weapongetbefore[1]*7+weapongetlevel[weapongetbefore[1]]];
            if(weapongetbefore[2]>4) t3.text=weaponstring[weapongetbefore[2]+30]; else t3.text=weaponstring[weapongetbefore[2]*7+weapongetlevel[weapongetbefore[2]]];
          
            Time.timeScale = 0f;
            MenuLevelup.SetActive(true);
        }

        //debug
        if (Input.GetKeyDown ("p")) {
            weapongetlevel[pp/7] = pp%7;
            retdata();
            dataupdate();
            pp++;
        }
    }
    
    public void retdata(){
        tdata.text = "Life : "+player_control.PlayerLife+" / "+player_control.PlayerMaxLife+"\nScore : "+player_control.PlayerScore+" / "+player_control.PlayerMAXScore+"\n\n";
        tdata.text += "Might : "+player_control.PlayerMight+"\nArmor : "+player_control.PlayerArmor+"\nRecovery : "+player_control.PlayerRecovery+"\nCooldown : "+player_control.PlayerCooldown+"\nDuration : "+player_control.PlayerDuration+"\nMoveSpeed : "+player_control.PlayerMoveSpeed+"\nGrowth : "+player_control.PlayerGrowth+"\n\n";
        tdata.text += "領域 : "+weapongetlevel[0]+"   立場 : "+weapongetlevel[1]+"\n追蹤 : "+weapongetlevel[2]+"   守衛 : "+weapongetlevel[3]+"\n雷射 : "+weapongetlevel[4];
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void btn1(){
        Time.timeScale = 1f;
        if(weapongetbefore[0]<5){
            if(weapongetlevel[weapongetbefore[0]]<6){
                weapongetlevel[weapongetbefore[0]]++;
            }else{
                ll(weapongetbefore[0]+5);
            }
        }else{
            ll(weapongetbefore[0]);
        }        
        
        dataupdate();
    }

    public void btn2(){
        Time.timeScale = 1f;
        if(weapongetbefore[1]<5){
            if(weapongetlevel[weapongetbefore[1]]<6){
                weapongetlevel[weapongetbefore[1]]++;
            }else{
                ll(weapongetbefore[1]+5);
            }
        }else{
            ll(weapongetbefore[1]);
        }  
        
        dataupdate();
    }

    public void btn3(){
        Time.timeScale = 1f;
        if(weapongetbefore[2]<5){
            if(weapongetlevel[weapongetbefore[2]]<6){
                weapongetlevel[weapongetbefore[2]]++;
            }else{
                ll(weapongetbefore[2]+5);
            }
        }else{
            ll(weapongetbefore[2]);
        }  
        
        dataupdate();
    }

    public void ll(int i){
        if(i==5) player_control.PlayerMaxLife *= 1.1f;
        if(i==6) player_control.PlayerArmor = (player_control.PlayerArmor*1.2f)%3;
        if(i==7) player_control.PlayerRecovery += 0.8f;
        if(i==8) player_control.PlayerCooldown *= 0.8f;
        if(i==9) player_control.PlayerMoveSpeed *= 1.2f;
        if(i==10) player_control.PlayerGrowth *= 1.1f;
    }

    public void dataupdate(){
        //w0
        player_weapon.weapon_damage[0] = player_control.PlayerMight * weapongetlevel[0] * 0.5f;
        if(weapongetlevel[0]==4) w0Cooldown=2f;
        if(weapongetlevel[0]==5) w0Cooldown=3f;
        if(weapongetlevel[0]==6) w0Cooldown=4f;
        //w1
        player_weapon.weapon_damage[1] = player_control.PlayerMight * weapongetlevel[1] * 0.5f;
        if(weapongetlevel[1]>2) player_weapon.weapon_damage[1] *= Mathf.Pow(1.2f,(weapongetlevel[1]-2)); 
        //w2
        player_weapon.weapon_damage[2] = player_control.PlayerMight * weapongetlevel[2] * 4f;
        //w3
        player_weapon.weapon_damage[3] = player_control.PlayerMight * weapongetlevel[3] * 4f;
        //w4
        player_weapon.weapon_damage[4] = player_control.PlayerMight * weapongetlevel[4] * 6f;
        if(weapongetlevel[4]>3) player_weapon.weapon_damage[4] *= Mathf.Pow(1.2f,(weapongetlevel[4]-2));

        MenuLevelup.SetActive(false);
    }

    public void ExitGame(){
        SceneManager.LoadScene("scene_menu");
    } 
}
