using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Entity : MonoBehaviour
{

    [SerializeField] uint id; //random number give at connection

    [SerializeField] PM_Stats stats;

    [SerializeField] PM_TeamManager teamManager;

    [SerializeField] List<PM_Skill> allSkills;

    [SerializeField] List<PM_Effect> allEffects; // Apply each turn 

    public PM_Stats Stats { get => stats; }
    public PM_TeamManager TeamManager { get => teamManager; }
    public uint ID { get => id; }

    #region ManageEffect

    public void AddEffect(PM_Effect _effect)
    {
        allEffects.Add(_effect);
    }
    public void RemoveEffect(PM_Effect _effect)
    {
        allEffects.Remove(_effect);
    }


    #endregion




}
