﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject trail;
    Animator animator;
    CharacterController controller;

    bool Attack_Success = false;

    private void Awake()
    {
        if(controller == null)
            controller = GetComponent<CharacterController>();
        if(animator == null)
            animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Start()
    {
        UIEventToGame.Instance.playerAttack += playerAttack;
        GameEventToUI.Instance.Attack_SuccessEvent += Attack_SuccessEvent;
    }

    private void Update()
    {
        //if (GameData.Instance.player.m_state == State.PlayerState.P_Guard)
        //{
        //    animator.SetTrigger("NextSkill");
        //    GameEventToUI.Instance.OnSkillGaugeActive(true);
        //    Attack_Success = true;
        //}

        if (Attack_Success)
            Attack_Success = false;
    }

    private void OnDestroy()
    {
        UIEventToGame.Instance.playerAttack += playerAttack;
    }

    void playerAttack(float time, COLORZONE color)
    {
        switch (GameData.Instance.player.m_state)
        {
            case State.PlayerState.P_Idle:
            case State.PlayerState.P_Run:
                //if (stateEventManager.Instance.OnPlayer_AttackEvent())
                //{
                //    animator.Play("First_Skill");
                //    GameEventToUI.Instance.OnSkillGaugeActive(true);
                //}
                //else
                //animator.SetTrigger("Guard");
                animator.Play("First_Skill");
                GameEventToUI.Instance.OnSkillGaugeActive(true);
                Attack_Success = true;
                //StartCoroutine(MoveToEnemy(CheckEnemys()));
                break;
            case State.PlayerState.P_Dash:
                break;
            case State.PlayerState.P_Guard:
                break;
            case State.PlayerState.P_1st_Skill:
                switch (color)
                {
                    case COLORZONE.NONE:
                        GameEventToUI.Instance.OnSkillGaugeActive(false);
                        break;
                    case COLORZONE.GREEN:
                    case COLORZONE.YELLOW:
                    case COLORZONE.RED:
                        Attack_Success = true;
                        animator.SetTrigger("NextSkill");
                        GameEventToUI.Instance.OnSkillGaugeActive(false);
                        GameEventToUI.Instance.OnSkillGaugeActive(true);
                        break;
                }
                break;
            case State.PlayerState.P_2nd_Skill:
                switch (color)
                {
                    case COLORZONE.NONE:
                        GameEventToUI.Instance.OnSkillGaugeActive(false);
                        break;
                    case COLORZONE.GREEN:
                    case COLORZONE.YELLOW:
                    case COLORZONE.RED:
                        Attack_Success = true;
                        animator.SetTrigger("NextSkill");
                        GameEventToUI.Instance.OnSkillGaugeActive(false);
                        break;
                }
                break;
            case State.PlayerState.P_3rd_Skill:
                break;
            case State.PlayerState.P_Delay:
                break;
            default:
                break;
        }
    }

    public bool Attack_SuccessEvent()
    {
        return Attack_Success;
    }

    Transform CheckEnemys()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 8f, LayerMask.GetMask("Enemy"));
        float dist = 0f;
        Transform T = null;
        foreach(var col in colliders)
        {
            float d = Vector3.Distance(transform.position, col.transform.position);
            if (dist == 0 || d < dist)
            {
                dist = d;
                T = col.transform;
            }
        }

        Debug.Log(dist);
        return T;
    }

    IEnumerator MoveToEnemy(Transform T)
    {
        //트레일 이펙트 켜기
        StartCoroutine(SetTrail());
        yield return new WaitForEndOfFrame();
        Vector3 dir = T.position - transform.position;
        dir.y = 0;
        float d = dir.magnitude - 1.5f;
        dir.Normalize();
        controller.Move(dir * d);
        transform.LookAt(transform.position + dir);
    }

    IEnumerator SetTrail()
    {
        trail.SetActive(true);
        yield return new WaitForSeconds(1);
        trail.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 8);
    }
}
