using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PM_TeamManager
{
    [SerializeField] List<PM_Entity> team = new List<PM_Entity>();

   // Pm_pl managerTeam = null;

    public List<PM_Entity> Team { get => team; }

  //  public PM_Entity TeamManager { get => managerTeam; }

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
        _entite.TeamManager.AddEntites(team);

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
            team.Add(_entite);
        else
            team.Remove(_entite);
    }

    #endregion



}
