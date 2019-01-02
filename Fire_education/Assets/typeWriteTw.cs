﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule.Tests;


public class typeWriteTw : MonoBehaviour
{

    //변경할 변수
    public float delay;
    public float Skip_delay;
    public int cnt;

    //타이핑효과 변수
    public string[] fulltext;
    public int dialog_cnt;
    string currentText;

    //타이핑확인 변수
    public bool text_exit;
    public bool text_full;
    public bool text_cut;

    public bool txtStart = true;


    //시작과 동시에 타이핑시작
    void Start()
    {
        // Get_Typing(dialog_cnt, fulltext);
    }


    //모든 텍스트 호출완료시 탈출
    void Update()
    {

        if (TowelUseButton.CUBInstance.press == 2 && txtStart)
        {
            Get_Typing(dialog_cnt, fulltext);
            txtStart = false;
            TowelUseButton.CUBInstance.press = 0;
        }
        if (text_exit == true)
        {
            gameObject.SetActive(false);
        }

    }



    //텍스트 시작호출
    public void Get_Typing(int _dialog_cnt, string[] _fullText)
    {
        //재사용을 위한 변수초기화
        text_exit = false;
        text_full = false;
        text_cut = false;
        cnt = 0;

        //변수 불러오기
        dialog_cnt = _dialog_cnt;
        fulltext = new string[dialog_cnt];
        fulltext = _fullText;

        //타이핑 코루틴시작
        StartCoroutine(ShowText(fulltext));
    }

    IEnumerator ShowText(string[] _fullText)
    {
        int j = 0;
        //모든텍스트 종료
        if (cnt >= dialog_cnt)
        {
            text_exit = true;
            StopCoroutine("showText");
        }
        else
        {
            //기존문구clear
            currentText = "";
            //타이핑 시작

            for (int i = 0; i < _fullText[cnt].Length; i++)
            {

                //타이핑중도탈출
                if (text_cut == true)
                {
                    break;
                }
                //단어하나씩출력
                currentText = _fullText[cnt].Substring(j, i + 1 - j);
                if (currentText[currentText.Length - 1] == '@')
                {
                    j = i + 1;
                }
                currentText = _fullText[cnt].Substring(j, i + 1 - j);
                this.GetComponent<Text>().text = currentText;

                yield return new WaitForSeconds(delay);
            }
            //탈출시 모든 문자출력
            Debug.Log("Typing 종료");
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(Skip_delay);

            //스킵_지연후 종료
            Debug.Log("Enter 대기");
            text_full = true;
        }
    }
}

