﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRolin : MonoBehaviour
{
    Vector3 originPos;
    [SerializeField] int[] talk_id;
    int count;

    public GameObject Box;
    private bool trigger =false;
    private bool isChack;
    private bool inTrue;
    private bool isTalk;
    void Start()
    {
       // NpcSetting();
        GameEventToUI.Instance.player_Trigger += isTrigger;


    }
    private void Update()
    {
        
        if (isChack && !isTalk)
        {
            isTalk = true;
            isChack = false;
            GameEventToUI.Instance.talkBtnEvent += TalkChange;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!inTrue && other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameEventToUI.Instance.talkBtnEvent += TalkChange;
            inTrue = true;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Vector3 pos = other.gameObject.transform.position - gameObject.transform.position;
            pos.y = 0;

            gameObject.transform.LookAt(gameObject.transform.position + pos);
            GameEventToUI.Instance.OnEventTalkBtn(true);
            GameEventToUI.Instance.talk_box += return_Talk_id;
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            GameEventToUI.Instance.OnEventTalkBtn(false);
            GameEventToUI.Instance.talk_box -= return_Talk_id;
            trigger = false;
        }
    }

    public bool isTrigger()
    {
        return trigger;
    }

    public int return_Talk_id()
    {
        return talk_id[count];
    }

    public void TalkChange()
    {
        isChack = true;
        count++;
        Box.SetActive(false);
        GameEventToUI.Instance.talkBtnEvent -= TalkChange;
    }
}
