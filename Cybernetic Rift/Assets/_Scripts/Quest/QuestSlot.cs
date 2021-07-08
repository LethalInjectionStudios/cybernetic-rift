using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    private bool _isCompleted = false;
    private QuestUI _questUI;

    // Start is called before the first frame update
    void Start()
    {
        _questUI = GetComponentInParent<QuestUI>();
    }

    public void LoadData(Quest questData)
    {
        _title.text = questData.Title;
        _description.text = questData.Description;
        //_isCompleted = questData.isCompleted;

        if(_isCompleted)
        {
            _title.fontStyle = FontStyles.Strikethrough;
            _description.fontStyle = FontStyles.Strikethrough;
        }
    }
}
