using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicController : MonoBehaviour
{
    public Relic relicData;

    void OnMouseOver()
    {
        Debug.Log(relicData.relicName);
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse is no longer on GameObject.");
    }

    public void setRelicData(Relic _relicData)
    {
        relicData = _relicData;
    }
}
