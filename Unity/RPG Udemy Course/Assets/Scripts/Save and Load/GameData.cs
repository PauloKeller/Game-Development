using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currency = 0;

    public SerializableDictionary<string, bool> skillTree;
    public SerializableDictionary<string, int> inventory;
    public List<string> equipmentId;

    public SerializableDictionary<string, bool> checkpoints;
    public string closestCheckpointId;

    public GameData()
    { 
        this.currency = 0;
        this.skillTree = new SerializableDictionary<string, bool>();
        this.inventory = new SerializableDictionary<string, int>();
        equipmentId = new List<string>();
        this.checkpoints = new SerializableDictionary<string, bool>();
        this.closestCheckpointId = string.Empty;
    }
}