using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_EntiteStatsTester : MonoBehaviour
{

    [SerializeField] public PM_Entity entite;

    public void UpStats(Stats _stat, float _value)
    {
        switch (_stat)
        {
            case Stats.Life:
                entite.Stats.UpLife(_value);
                break;
            case Stats.Mana:
                entite.Stats.UpMana(_value);
                break;
            case Stats.Stamina:
                entite.Stats.UpStamina(_value);
                break;
            case Stats.Experience:
                entite.Stats.UpExperience(_value);
                break;
            case Stats.None:
                break;
        }
    }

    public void DownStats(Stats _stat, float _value)
    {
        switch (_stat)
        {
            case Stats.Life:
                entite.Stats.DownLife(_value);
                break;
            case Stats.Mana:
                entite.Stats.DownMana(_value);
                break;
            case Stats.Stamina:
                entite.Stats.DownStamina(_value);
                break;
            case Stats.Experience:
                entite.Stats.DownExperience(_value);
                break;
            case Stats.None:
                break;
        }
    }

}
