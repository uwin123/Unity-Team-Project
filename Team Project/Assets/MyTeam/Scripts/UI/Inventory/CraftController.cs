﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftController : MonoBehaviour
{
    //장비 아이템 리스트
    public GameObject EquipButtonGroup;
    private Dictionary<EQUIPMENTTYPE, Transform> equipButtons;
    [SerializeField]
    Button[] btns;
    //플레이어 장비아이템 리스트
    private List<Equipment> pEquip;
    //제작 아이템 리스트
    private Dictionary<string, Transform> prodButtons;
    private void Start()
    {
        equipButtons = new Dictionary<EQUIPMENTTYPE, Transform>();
        btns = EquipButtonGroup.GetComponentsInChildren<Button>();
        //버튼들을 장비타입 (HELM, WEAPON 등등)을 키값으로 검색할 수 있게 딕셔너리로 생성
        for (int i = 0; i < btns.Length; i++)
        {
            equipButtons.Add((EQUIPMENTTYPE)i, btns[i].transform);
        }
        pEquip = DataManager.Instance.EquipInvenData.CurrentEquipmentList;
        SetEquipItem();
    }
    //장비 아이템 버튼 이미지 조정
    public void SetEquipItem()
    {
        for (int i = 0; i < pEquip.Count; i++)
        {
            Image itemGradeImage = equipButtons[pEquip[i].equipmentType].GetChild(0).GetComponent<Image>();
            equipButtons[pEquip[i].equipmentType].GetChild(1).GetComponent<Image>().sprite = Inventory.Instance.itemImages[pEquip[i].itemScriptID];
            switch (pEquip[i].itemGrade)
            {
                case 1:
                    itemGradeImage.color = Color.gray;
                    break;
                case 2:
                    itemGradeImage.color = Color.blue ;
                    break;
                case 3:
                    itemGradeImage.color = Color.red;
                    break;
            }
        }
    }
    public void SetCraftTree(Equipment e)
    {
        Production p = new Production();
        foreach (var item in GameData.Instance.producitonData)
        {
            if (item.productionID == e.productionID)
            {
                p = item;
                break;
            }
        }

    }
}
