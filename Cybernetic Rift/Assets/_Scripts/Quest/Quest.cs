using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    private string _title;
    private string _description;

    public Quest(QuestData data)
    {
        _title = data.name;
        _description = data.description;
    }

    public string Title
    {
        get => _title;
    }

    public string Description
    {
        get => _description;
    }
}
