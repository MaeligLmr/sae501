using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "VariableRegistry", menuName = "Conditions/Variable Registry", order = 1)]
public class VariableRegistry : ScriptableObject
{
    public List<VariableDefinition> variables; // List of allowed variables
}

[System.Serializable]
public class VariableDefinition
{
    public string name; // Variable name
    public VariableType type; // Variable type
}

public enum VariableType { String, Integer, Float, Boolean }
