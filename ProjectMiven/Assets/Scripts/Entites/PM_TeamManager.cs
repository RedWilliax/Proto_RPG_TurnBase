using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PM_TeamManager : MonoBehaviour
{
    [SerializeField] List<PM_Entity> team = new List<PM_Entity>();

    [SerializeField] PM_Entity managerTeam = null;

    public List<PM_Entity> Team { get => team; }

    public PM_Entity ManagerTeam { get => managerTeam; }

    #region TeamManage

    #region Add
    public void AddEntites(List<PM_Entity> _entites)
    {
        for (int i = 0; i < _entites.Count; i++)
            AddEntite(_entites[i]);
    }

    public void AddEntite(PM_Entity _entite)
    {
        ManageTeam(true, _entite);
    }
    #endregion

    #region Remove

    public void ClearTeam()
    {
        RemoveEntites(team);
    }

    public void RemoveEntites(List<PM_Entity> _entites)
    {
        for (int i = 0; i < _entites.Count; i++)
            RemoveEntite(_entites[i]);
    }

    public void RemoveEntite(PM_Entity _entite)
    {
        ManageTeam(false, _entite);
    }
    #endregion

    public bool EntiteExist(PM_Entity _entite)
    {
        return team.Any(n => n.ID == _entite.ID);
    }

    void ManageTeam(bool _add, PM_Entity _entite)
    {
        if (_add ? EntiteExist(_entite) : !EntiteExist(_entite)) return;

        if (_add)
        {
            if (team.Count <= 0)
                SetManagerTeam(_entite);

            team.Add(_entite);

            _entite.SetTeamManager(this);
        }
        else
        {
            if(_entite.ID == managerTeam.ID)
                _entite.UnsubscribeMove();

            _entite.SetTeamManager(null);

            team.Remove(_entite);

            AllocateManagerTeam();
        }
    }

    public void SetManagerTeam(PM_Entity _entity)
    {
        if(ExistManagerTeam(out int _index))
            team[_index].UnsubscribeMove();
        
        managerTeam = _entity;
        _entity.SubscribeMove();
    }

    void AllocateManagerTeam()
    {
        if (team.Count <= 0)
            return;

        SetManagerTeam(team[0]);
    }

    bool ExistManagerTeam(out int _index)
    {
        _index = -1;

        for (int i = 0; i < team.Count ; i++)
        {

            if (team[i].ID == managerTeam.ID)
            {
                _index = i;
                return true;
            }
        }

        return false;
    }

    #endregion

    public void LateUpdate()
    {
        if (!managerTeam) return;

        for (int i = 0; i < team.Count; i++)
        {
            if (team[i].ID == managerTeam.ID)
                continue;

            team[i].Move(managerTeam.transform.position);
        }
    }



}
