using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour
{
    private List<Quest> _questList = new List<Quest>();

    public void AddQuest(Quest quest)
    {
        _questList.Add(quest);
    }

    public void CompleteQuest()
    {
        throw new System.NotImplementedException();
    }

    public List<Quest> GetQuestList()
    {
        return _questList;
    }
}
