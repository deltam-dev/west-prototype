using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Destructible Data", menuName ="Destructible Data")]
public class DestructibleData : ScriptableObject
{
    [SerializeField] private string objName;
    [SerializeField] private int vida;

    public string Name { get { return objName; } }
    public int Vida { get { return vida;  } }
}
