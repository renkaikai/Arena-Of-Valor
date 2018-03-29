using System;
using UnityEngine;

public class SkillSelecting : MonoBehaviour {

    public event Action<Skill> OnSelect;

    private SkillsPanel skillsPanel;

    private Skill selectedSkill;

	// Use this for initialization
	void Start () {
        //skillsPanel.OnSelectdValueChanged += SkillsPanel_OnSelectdValueChanged;		
	}
    
    private void SkillsPanel_OnSelectdValueChanged(Skill obj)
    {
        selectedSkill = obj;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void Button_Click()
    {
        if(OnSelect != null)
        {
            OnSelect(selectedSkill);
        }
    }
}
