using UnityEngine;

[CreateAssetMenu(fileName = "IngrediantScriptable", menuName = "Scriptable Objects/IngrediantScriptable")]
public class IngrediantScriptable : ScriptableObject
{
    public string iName;
    public Sprite sprite;
    public int index;
    public string description;
    public string requestDescirption;
    public string extraRequestDesciption;

    public int val;
}
