using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour, IClickable
{
    public Vector3 closedPos, openPos;
    bool open = false;
    public float speed;
    int page = 1;
    public BookButtons[] buttons;
    Queue<Ingredient> ingredients;

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++) 
        {
            buttons[i].SetIndex(i,this);
        }
    }

    private void Update()
    {
        if (open)
        {
            transform.position = Vector3.Lerp(transform.position, openPos, speed * Time.deltaTime);
        }
        else 
        {
            transform.position = Vector3.Lerp(transform.position, closedPos, speed * Time.deltaTime);
        }
    }

    public void OnClick() 
    {
        open ^= true;
    }

    public void CancelClick() 
    { 
    
    }

    public void CreateIngredient(int index) 
    {
        Debug.Log(index);
        if (ingredients.Count > 0) 
        {
            Ingredient ingre = ingredients.Dequeue();
            ingre.SetIngredient(IngredientsContainer.ingreScriptables[index]);
        }
    }
}
