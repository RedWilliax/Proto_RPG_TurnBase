using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_EntiteTeamManagerTester : MonoBehaviour
{
    [SerializeField] public List<PM_Entity> entite;
    [SerializeField] PM_TeamManager teamManager;


    public void TeamUp(List<PM_Entity> _entite)
    {
        for (int i = 0; i < _entite.Count; i++)
        {
            teamManager.AddEntites(entite);
        }
    }

    public void Disband()
    {
        for (int i = 0; i < entite.Count; i++)
        {
            teamManager.ClearTeam();
        }

    }

}
