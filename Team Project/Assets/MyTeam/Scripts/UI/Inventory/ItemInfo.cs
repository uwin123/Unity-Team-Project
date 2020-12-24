﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemInfo : MonoBehaviour, IPointerClickHandler
{
    GameData data;
    private int slotNum;
    public Canvas infoScreen;
    public Image image;
    public Transform infoUI;
    public TMP_Text TName;
    public TMP_Text TCategory;
    public TMP_Text TDescription;
    public TMP_Text TStat;
    public TMP_Text TSubStat;

    public void SetSlotNum(int num)
    {
        slotNum = num;
    }

    private void Start()
    {
        data = GameData.Instance;
    }
    public void ShowItemInfo()
    {
        if (!infoScreen.gameObject.activeSelf)
        {
            infoScreen.gameObject.SetActive(true);
            infoScreen.transform.position =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            infoScreen.gameObject.SetActive(false);
            infoScreen.gameObject.SetActive(true);
        }
        if (slotNum < data.equipmentData.Count)
        {
            //아이템 이미지 받아와 넣기
            TName.text = Inventory.Instance.pInven[slotNum].name;
            TCategory.text = Inventory.Instance.pInven[slotNum].itemCategory.ToString();
            image.sprite = Inventory.Instance.pInven[slotNum].image;
            //아이템 설명 TDescription.text = data.equipmentData[slotNum].;
            TStat.text = data.equipmentData[slotNum].itemGrade;
            TSubStat.text = "ID : " + data.equipmentData[slotNum].ID;
        }
    }
    public void RefreshCount(bool isAdded)
    {
        if (isAdded)
        {
            gameObject.GetComponent<Slot.SlotAddition>().SetCountText(Inventory.Instance.pInven[slotNum].count.ToString());
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        ShowItemInfo();
    }
}