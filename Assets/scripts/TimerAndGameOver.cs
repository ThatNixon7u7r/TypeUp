using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAndGameOver : MonoBehaviour
{//1013336184 

    float maxTime= 120f, currentTime;
    public Image timeBar;
    public static int mistakes=0;
    public Canvas[] mistakeIcon;
    public Canvas[] panels;
    public Text[] score;

    void Start(){
        currentTime=maxTime;
        reset();
    }   
    void Update(){
        //currentTime-=Time.time;
        timeBar.fillAmount = (((maxTime-Time.time)*100)/120)/100;
        if(timeBar.fillAmount==0)
            GameOver(false);
        switch (mistakes)
        {
            case 1:
                mistakeIcon[0].enabled=true;
                break;
            case 2:
                mistakeIcon[1].enabled=true;
                break;
            case 3:
                mistakeIcon[2].enabled=true;
                GameOver(true);
                break;
        }
    }
    public void GameOver(bool badGame){
        if(badGame==true){
            panels[0].enabled=true;
            score[0].text=GameData.score.ToString();
        }else{
            panels[1].enabled=true;
            score[1].text=GameData.score.ToString();
        }
        Time.timeScale=0;
    }
    public void reset(){
        panels[0].enabled=false;
        panels[1].enabled=false;
        //GameData.score=0;
    }
}
