using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsGenerator : MonoBehaviour
{

    public Roots[] roots;
    public Canvas[]  btnChars;
    public Text[] txtChars, txtWord;
    public Text hint;
    string[] tempChar;
    int typePos=0, typeCounter=0;
    char[] word, answer;
    int goodAnswer=1;

    void Start(){
        GenerateWords();
        resertScene(0);
    }

    void Update(){
    }
    void GenerateWords(){
        int x = Random.Range(0,roots.Length);
        string r = roots[x].name;
        hint.text=roots[x].resume;
        word = r.ToCharArray();
        switch (word.Length){
            case 1:
                typePos=3;
                break;
            case 2:
                typePos=3;
                break;
            case 3:
                typePos=2;
                break;
            case 4:
                typePos=2;
                break;
            case 5:
                typePos=1;
                break;
            case 6:
                typePos=1;
                break;
            case 7:
                typePos=0;
                break;
        }
        //Button's enabled and disabled
        for (int i = 0; i < btnChars.Length; i++)
            btnChars[i].enabled=false;
        for (int i = 0; i < roots[x].holders.Length; i++)
            roots[x].holders[i].enabled = true;
        //Button's text
        for (int i = 0; i < word.Length; i++)
            txtChars[i].text = word[i].ToString();
        //KeyBoard
        int j = word.Length;
        for (int i = word.Length; i < txtChars.Length; i++){
            txtChars[i].text= ((char)('a'+((int)(Random.Range(0,26))))).ToString();
        }
        for (int i = 0; i < word.Length; i++){
            txtChars[i].text=word[j].ToString();
            j--; 
        }
        Debug.ClearDeveloperConsole();
    }
    public void unGenerateWords(){
        for (int i = 0; i < txtWord.Length; i++){
            txtWord[i].text="";
        }
        for (int i = 0; i < btnChars.Length; i++)
            btnChars[i].enabled=false;
        typeCounter=0;
        goodAnswer=1;
        GenerateWords();
    }
    public void typeChar(int i){
        //Debug.Log(txtWord[typePos].text.ToString());
        //answer[typePos]=char.Parse(txtChars[i].text);
        txtWord[typePos].text=txtChars[i].text;
        typePos++;
        typeCounter++;
        //Debug.Log(txtChars[i].text+"  ,  "+word[typeCounter-1].ToString());
        if(txtChars[i].text==word[typeCounter-1].ToString())
            goodAnswer++;
        if(goodAnswer==word.Length+1&&typeCounter==word.Length)
            nextWord();
        else if (goodAnswer<word.Length+1&&typeCounter==word.Length){
            TimerAndGameOver.mistakes++;
            GameData.score-=10;
            nextWord();
        }
        Debug.ClearDeveloperConsole();
    }
    public void unTypeChar(int i){
        txtWord[typePos].text="";
        if(typePos>0)
            typePos--;
        if(typeCounter>0)
            typeCounter--;
        if(txtChars[i].text==word[typeCounter-1].ToString()){
            goodAnswer--;
        }
        Debug.ClearDeveloperConsole();
    }
    void nextWord(){
        GameData.score+=10;
        //Debug.Log(GameData.score);
        unGenerateWords();
    }
    public void resertScene(int j){
        typePos=1;
        typeCounter=0;
        for (int i = 0; i < txtWord.Length; i++)
        {
            txtWord[i].text="";
        }
    }
}