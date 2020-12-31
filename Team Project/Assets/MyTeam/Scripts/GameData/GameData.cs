﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSVReader;
using UnityEngine.SceneManagement;
public class GameData : SingletonMonobehaviour<GameData>
{
    private PlayerDataList playerDataList;
    public List<PlayerData> playerData;
    public Player player;
    public List<NPCReader.NPCTalk> data;
    public List<Equipment> equipmentData;


    private void Start()
    {
        
        //data = CSVReaderNPC.CSVReaderNPC.FileRead("talkdata");
        Table table = CSVReader.Reader.ReadCSVToTable("EquipmentData");
        equipmentData = table.TableToList<Equipment>();
        //System.GC.Collect();
        data = CSVReaderNPC.CSVReaderNPC.FileRead("talkdata");
        System.GC.Collect();

        player = new Player();

        playerDataList = JsonManager.Instance.LoadJsonFile<PlayerDataList>(Application.dataPath, "/MyTeam/Resources/PlayerData");
        playerData = playerDataList.datas;
        playerData[0].WriteData(in player);
        player.hp = 4;

        SceneManager.LoadScene("MainGameScene", LoadSceneMode.Additive);
    }

    public void Print()
    {
        foreach(Equipment a in equipmentData)
        {
            Debug.Log(a.ID + " " + a.name + " " + a.itemGrade);
        }
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F2))
        //{
        //    Print();
        //}
    }

    //아이템 매니저 함수들
    //===================================================================
    public Equipment findEquipment(string itemname)
    {
        int i;
        for (i = 0; i < equipmentData.Count; i++)
        {
            if (equipmentData[i].name.Equals(itemname))
            {
                break;
            }
        }
        if (i >= equipmentData.Count)
            return null;
    
        Equipment p = new Equipment();
        p = equipmentData[i];

        return p;
    }
    public Equipment findEquipmentByID(int _ID)
    {
        int i;
        for (i = 0; i < equipmentData.Count; i++)
        {
            if (equipmentData[i].ID.Equals(_ID))
            {
                break;
            }
        }
        if (i >= equipmentData.Count)
            return null;

        Equipment p = new Equipment();
        p = equipmentData[i];

        return p;
    }    //===================================================================
    //게임 끝날때 저장
    private void OnDestroy()
    {
        playerDataList.datas = playerData;
        JsonManager.Instance.CreateJsonFile(Application.dataPath, "/MyTeam/Resources/PlayerData", playerDataList);
    }

    //플레이어 슬롯에서 데이터 읽기
    public void LoadFromPlayerSlot(int slot)
    {
        playerData[slot].WriteData(in player);
    }

    //플레이어 슬롯 새로만들기
    public void CreateNewPlayerSlot(int slot, string name)
    {
        playerData[slot].CreateNewPlayer(slot, name);
    }

    public void DeletePlayerData(int slot)
    {
        playerData[slot].DeleteData(slot);
    }
}
