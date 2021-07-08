using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    private List<Quest> _quests;
    private GameObject _questSlots;
    [SerializeField] private QuestSlot _questSlot;

    private void OnEnable()
    {
        _questSlots = GameObject.FindGameObjectWithTag("QuestSlots");
        _quests = null;
        ClearUI();
        _quests = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestLog>().GetQuestList();
        PopulateQuestLog();
    }
    private void PopulateQuestLog()
    {
        foreach(Quest quest in _quests)
        {
            QuestSlot slot = Instantiate(_questSlot);
            slot.transform.SetParent(_questSlots.transform);
        }
    }

    private void ClearUI()
    {
        foreach(Transform child in _questSlots.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
