using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Entity : MonoBehaviour
{

    [SerializeField] protected uint id; //random number give at connection

    [SerializeField] protected PM_Stats stats;

    [SerializeField] protected PM_TeamManager teamManager;

    [SerializeField] protected List<PM_Skill> allSkills;

    [SerializeField] protected List<PM_Effect> allEffects; // Apply each turn 

    [SerializeField] protected PM_Movement movement;

    public PM_Stats Stats { get => stats; }
    public PM_TeamManager TeamManager { get => teamManager; }
    public uint ID { get => id; }

    private void Awake()
    {
        movement.InitMovement(this);

        teamManager.AddEntite(this);
    }

    private void Start()
    {
    }

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
