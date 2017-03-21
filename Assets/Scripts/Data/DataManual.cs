﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
	kkkkoyo original sample
*/
public class DataManual : MonoBehaviour
{
    /*パネルをスライド */
    [SerializeField] private PanelSlider panel;

    public void PanelSlideIn()
    {
        panel.SlideIn();
    }
    public void PanelSlideOut()
    {
        panel.SlideOut();
    }

    /*シーンの遷移*/
    public void GoNextScene(bool isAsynchronous, string SceneName)
    {
        if (isAsynchronous)
        {
            StartCoroutine(GoGame(SceneName));
        }
        else
        {
            SceneManager.LoadScene(SceneName);
        }
    }
    private IEnumerator GoGame(string SceneName)
    {
        AsyncOperation async;
        async = SceneManager.LoadSceneAsync(SceneName);
        yield return async;
    }
    private void ListPrac()
    {
        List<int> intList = new List<int>();    //int型のリスト
        intList.Add(1); // intList = {1}
        intList.Add(2); // intList = {1,2}
        intList.Add(3); // intList = {1,2,3}
        intList.RemoveAt(1);    // intList = {1,3}
        int b = intList[1]; // bには3が入る
        if(intList.Contains(1))
        {
            Debug.Log("1がある");
        }
    }

    //接触したときのイベント用メソッド 
    void OnTriggerEnter(Collider collider)
    {
    
    }
    //接触している間、常に発生し続けるイベント用メソッド 
    void OnTriggerStay(Collider collider) 
    {

    }
    //離れたときのイベント用メソッド 
    void OnTriggerExit(Collider collider) 
    {

    }

    //オブジェクトが衝突したとき
    void OnCollisionEnter(Collision collision)
    {

    }
    
    //オブジェクトが離れた時
    void OnCollisionExit(Collision collision)
    {

    }
    
    //オブジェクトが触れている間
    void OnCollisionStay(Collision collision)
    {

    }
}
