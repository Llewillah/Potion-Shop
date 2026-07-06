using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour, IClickable
{
    public Vector3 closedPos, openPos, ingreSpawnPos;
    bool open = false;
    public float speed;
    int page = 0;
    public BookButtons[] buttons;
    public GameObject[] ingrePrefab;
    Queue<Ingredient> ingredients = new Queue<Ingredient>();

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++) 
        {
            buttons[i].SetIndex(i,this);
        }

        foreach(GameObject obj in ingrePrefab) 
        {
            ingredients.Enqueue(obj.GetComponent<Ingredient>());
            obj.GetComponent<Ingredient>().SetBs(this);
            obj.SetActive(false);

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
        Debug.Log(index + buttons.Length * page);
        if (ingredients.Count > 0) 
        {
            Ingredient ingre = ingredients.Dequeue();
            ingre.gameObject.transform.position = ingreSpawnPos;
            ingre.SetIngredient(IngredientsContainer.instance.ingreScriptables[index + buttons.Length * page]);
        }
    }

    public void ResetIngredient(Ingredient i)
    {
        ingredients.Enqueue(i);
    }
}
