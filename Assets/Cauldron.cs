using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public float cookTime;
    bool cooking = false;
    float timer = 0;

    List<int> curMix = new List<int>();


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
        if (!cooking)
        {
            curMix.Add(index);
            Debug.Log(curMix);
        }
    }

    public void ToggleFlame() 
    {
        cooking ^= true;
    }

    void ResetCooking() 
    {
        cooking = false;
        timer = 0;
        curMix.Clear();
    } 

    public void FinishCook() 
    {

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

        ResetCooking();
    }
}
