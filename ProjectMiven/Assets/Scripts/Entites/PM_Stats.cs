using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum Stats
{
    Life,
    Mana,
    Stamina,
    Experience,
    None

}
[Serializable]
public class PM_Stats
{
    //Action OnUpdateStats
    //Action OnUpdateLife
    //Action OnUpdateMana
    //Action OnUpdateStamina
    //Action OnUpdateExperience

    [SerializeField] float life;
    [SerializeField] float mana;
    [SerializeField] float stamina;
    [SerializeField] float experience;

    #region ManageStats

    #region LifeManage
    public void UpLife(float _value)
    {
        ManageStat(Stats.Life, _value, true);
    }

    public void DownLife(float _value)
    {
        ManageStat(Stats.Life, _value, false);
    }
    #endregion

    #region ManaManage
    public void UpMana(float _value)
    {
        ManageStat(Stats.Mana, _value, true);
    }

    public void DownMana(float _value)
    {
        ManageStat(Stats.Mana, _value, false);
    }
    #endregion

    #region StaminaManage

    public void UpStamina(float _value)
    {
        ManageStat(Stats.Stamina, _value, true);
    }

    public void DownStamina(float _value)
    {
        ManageStat(Stats.Stamina, _value, false);
    }

    #endregion

    #region ExperienceManage

    public void UpExperience(float _value)
    {
        ManageStat(Stats.Experience, _value, true);
    }

    public void DownExperience(float _value)
    {
        ManageStat(Stats.Experience, _value, false);
    }

    #endregion

    void ManageStat(Stats _stats, float _value, bool _add)
    {
        switch (_stats)
        {
            case Stats.Life:
                {
                    life += _add ? _value : -_value;
                }
                break;
            case Stats.Mana:
                {
                    mana += _add ? _value : -_value;
                }
                break;
            case Stats.Stamina:
                {
                    stamina += _add ? _value : -_value;
                }
                break;
            case Stats.Experience:
                {
                    experience += _add ? _value : -_value;
                }
                break;
            case Stats.None:
                break;
        }
        Debug.Log("Manage Stat Did it");

    }

    #endregion

}
