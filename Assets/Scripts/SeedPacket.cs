using System;
using DefaultNamespace;
using UnityEngine;

[UnityEngine.CreateAssetMenu(fileName = "SeedPacket", menuName = "ScriptableObjects/SeedPacket", order = 2)]
public class SeedPacket : Item
{
    [SerializeField] private string seedType;
    public string SeedType => seedType;
}