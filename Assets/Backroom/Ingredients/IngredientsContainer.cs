using UnityEngine;

public class IngredientsContainer : MonoBehaviour
{
    public IngrediantScriptable[] ingreScriptables;
    public static IngredientsContainer instance;

    private void Start()
    {
        instance = this;

        for (int i = 0; i < ingreScriptables.Length; i++) 
        {
            ingreScriptables[i].index = i;
        }
    }
}
