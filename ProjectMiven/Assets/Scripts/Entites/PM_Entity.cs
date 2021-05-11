using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Entity : MonoBehaviour
{

    [SerializeField] protected uint id; //random number give at connection

    [SerializeField] protected PM_Stats stats;

    [SerializeField] protected PM_TeamManager teamManager = null;

    [SerializeField] protected List<PM_Skill> allSkills;

    [SerializeField] protected List<PM_Effect> allEffects; // Apply each turn 

    [SerializeField] protected PM_Movement movement;

    bool subscribeOnMove = false;

    public PM_Stats Stats { get => stats; }
    public PM_TeamManager TeamManager { get => teamManager; }
    public uint ID { get => id; }

    private void Awake()
    {
        movement.InitMovement(this);
    }

    private void Start()
    {
    }

    public void SetTeamManager(PM_TeamManager _teamManager)
    {
        teamManager = _teamManager;
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

    #region Movement
    public void Move(Vector3 _pos)
    {
        movement.Move(_pos);
    }

    public void SubscribeMove()
    {
        if (subscribeOnMove) return;
        PM_InputManager.OnClickLeftMouse += MoveEntity;
        subscribeOnMove = true;
    }

    public void UnsubscribeMove()
    {
        if (!subscribeOnMove) return;
        PM_InputManager.OnClickLeftMouse -= MoveEntity;
        subscribeOnMove = false;
    }


    void MoveEntity(bool _do)
    {
        if (_do)
            Move(PM_MousePointer.MousePosition);
    }

    #endregion

}
