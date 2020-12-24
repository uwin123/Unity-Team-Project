﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        UIEventToGame.Instance.playerAttack += playerAttack;
    }

    private void OnDestroy()
    {
        UIEventToGame.Instance.playerAttack += playerAttack;
    }

    void playerAttack(float time, COLORZONE color)
    {
        Debug.Log(color);
        switch (GameData.Instance.player.m_state)
        {
            case State.PlayerState.P_Guard:
                if(time < 1.1f)
                {
                    animator.SetTrigger("NextSkill");
                    GameEventToUI.Instance.OnSkillGaugeActive(true);
                }
                break;
            case State.PlayerState.P_1st_Skill:
                switch (color)
                {
                    case COLORZONE.NONE:
                        GameEventToUI.Instance.OnSkillGaugeActive(false);
                        break;
                    case COLORZONE.GREEN:
                        animator.SetTrigger("NextSkill");
                        GameEventToUI.Instance.OnSkillGaugeActive(false);
                        GameEventToUI.Instance.OnSkillGaugeActive(true);
                        break;
                    case COLORZONE.YELLOW:
                        animator.SetTrigger("NextSkill");
                        GameEventToUI.Instance.OnSkillGaugeActive(false);
                        GameEventToUI.Instance.OnSkillGaugeActive(true);
                        break;
                    case COLORZONE.RED:
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
                        animator.SetTrigger("NextSkill");
                        GameEventToUI.Instance.OnSkillGaugeActive(false);
                        break;
                    case COLORZONE.YELLOW:
                        animator.SetTrigger("NextSkill");
                        GameEventToUI.Instance.OnSkillGaugeActive(false);
                        break;
                    case COLORZONE.RED:
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
                animator.SetTrigger("Guard");
                break;
        }
    }

}