﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TartosPattom2_2 : StateMachineBehaviour
{
    BossData tartos;
    BossTartos bossTartos;

    GameObject patton2_1;
    GameObject patton2_2;
    GameObject patton2_3;
    GameObject patton2_4;
    GameObject patton2_5;
    GameObject patton2_6;
    GameObject patton2_7;
    GameObject patton2_8;

    GameObject patton2_C;

    TartosPattom2_1 num;
    int number2;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (tartos == null)
            tartos = animator.transform.parent.GetComponent<BossData>();
        tartos.bossState = State.BossState.B_SkillChargeTwo;

        if (bossTartos == null)
            bossTartos = animator.transform.parent.GetComponent<BossTartos>();

        if (num == null)
            num = animator.GetBehaviour<TartosPattom2_1>();

        SoundManager.Instance.OnPlayOneShot(SoundKind.Sound_Chapter2_Boss, "Pattern2");

        tartos.position.position = bossTartos.pattern2Point.position;
        tartos.navigation.SetDestination(bossTartos.pattern2Point.position);

        number2 = num.number;

        if (patton2_1 == null)
            patton2_1 = animator.transform.parent.GetComponent<BossTartos>().tartosPatton2_1;
        if (patton2_2 == null)
            patton2_2 = animator.transform.parent.GetComponent<BossTartos>().tartosPatton2_2;
        if (patton2_3 == null)
            patton2_3 = animator.transform.parent.GetComponent<BossTartos>().tartosPatton2_3;
        if (patton2_4 == null)
            patton2_4 = animator.transform.parent.GetComponent<BossTartos>().tartosPatton2_4;
        if (patton2_5 == null)
            patton2_5 = animator.transform.parent.GetComponent<BossTartos>().tartosPatton2_5;
        if (patton2_6 == null)
            patton2_6 = animator.transform.parent.GetComponent<BossTartos>().tartosPatton2_6;
        if (patton2_7 == null)
            patton2_7 = animator.transform.parent.GetComponent<BossTartos>().tartosPatton2_7;
        if (patton2_8 == null)
            patton2_8 = animator.transform.parent.GetComponent<BossTartos>().tartosPatton2_8;
        if (patton2_C == null)
            patton2_C = animator.transform.parent.GetComponent<BossTartos>().tartosPatton2_Center;

        if (number2 == 2)
            animator.SetBool("pattern3", true);
        else
            animator.SetBool("pattern3", false);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tartos.position.position = bossTartos.pattern2Point.position;
        tartos.transform.rotation = Quaternion.Euler(0, -90, 0);
        if (number2 == 0)
        {
            patton2_5.SetActive(true);
            patton2_6.SetActive(true);
            patton2_7.SetActive(true);
            patton2_8.SetActive(true);
        }
        else if (number2 == 1)
        {
            patton2_2.SetActive(true);
            patton2_4.SetActive(true);
            patton2_5.SetActive(true);
            patton2_7.SetActive(true);
        }
        else
        {
            patton2_3.SetActive(true);
            patton2_5.SetActive(true);
        }

    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (number2 == 0)
            bossTartos.PaticleOn2_1_2();
        else if (number2 == 1)
            bossTartos.PaticleOn2_2_2();
        else
            bossTartos.PaticleOn2_3_2();
            
        patton2_1.SetActive(false);
        patton2_2.SetActive(false);
        patton2_3.SetActive(false);
        patton2_4.SetActive(false);
        patton2_5.SetActive(false);
        patton2_6.SetActive(false);
        patton2_7.SetActive(false);
        patton2_8.SetActive(false);
        if (number2 != 2)
            patton2_C.SetActive(false);

    }
}
