﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossData : character
{
    public int skillid;                 //스킬 아이디
    public float counter_reslstance;    //카운터 저항
    public float attack_aware_distance;   //공격 거리

    public State.BossState bossState;

    public NavMeshAgent navigation;

    public Animator animator;
}
