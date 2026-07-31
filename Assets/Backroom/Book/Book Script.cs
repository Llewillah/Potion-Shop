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
        foreach (BookButtons b in buttons) 
        {
            b.gameObject.SetActive(false);
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
            transform.localPosition = Vector3.Lerp(transform.localPosition, openPos, speed * Time.deltaTime);
        }
        else 
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, closedPos, speed * Time.deltaTime);
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
            ingre.gameObject.transform.localPosition = ingreSpawnPos;
            ingre.SetIngredient(IngredientsContainer.instance.ingreScriptables[index + buttons.Length * page]);
        }
    }

    public void ResetIngredient(Ingredient i)
    {
        ingredients.Enqueue(i);
    }

    public void StartDay() 
    {
        for (int i = 0; i < ImportantInfo.levelsNumIngredients[ImportantInfo.level]; i++)
        {
            buttons[i].SetIndex(i, this);
            buttons[i].gameObject.SetActive(true);
        }
    }
}
