using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour
{
    [SerializeField] private List<Quest> _questList;

    public void AddQuest(Quest quest)
    {
        _questList.Add(quest);
    }

    public void CompleteQuest(Quest quest)
    {
        foreach(Quest _quest in _questList )
        {
            if(_quest == quest)
            {
                _quest.isCompleted = true;
            }
        }
    }

    public List<Quest> GetQuestList()
    {
        return _questList;
    }
}
