using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public float cookTime;
    bool cooking = false;
    float timer = 0;

    List<int> curMix = new List<int>();


    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (cooking) 
        {
            timer += Time.deltaTime;
        }
    }

    public void AddToMix(int index) 
    {
        curMix.Add(index);
        Debug.Log(curMix);
    }

    public void StartCook() 
    {
        timer = 0;
        cooking = true;
    }

    public void FinishCook() 
    {
        cooking = false;

        if (timer < cookTime)
        {
            //Undercooked
        }
        else if (timer > cookTime + cookTime / 2)
        {
            //Overcooked
        }
        else 
        {
            //Great!
        }
    }
}
