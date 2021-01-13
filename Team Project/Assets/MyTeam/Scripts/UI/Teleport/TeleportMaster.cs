﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportMaster : MonoBehaviour
{
    public Mesh Disable;
    public Mesh Active;

    [HideInInspector]
    public MeshFilter mesh;
    public string NextPortalName;
    public string NextSceneName;
    public bool isPossibleMove = false;

    private void Start()
    {
        mesh = GetComponent<MeshFilter>();
        if (!isPossibleMove && Disable != null)
            mesh.mesh = Disable;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPossibleMove) return;
        if (!other.CompareTag("Player")) return;
        if (GameData.Instance.player.isSceneMove) return;
        if (NextPortalName == "") return;
        SceneMgr.Instance.LoadScene(NextSceneName, NextPortalName);
    }

    private void OnTriggerExit(Collider other)
    {
        if (GameData.Instance.player.isSceneMove)
            GameData.Instance.player.isSceneMove = false;
    }
}
