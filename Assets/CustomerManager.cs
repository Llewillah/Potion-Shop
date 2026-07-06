using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class CustomerManager : MonoBehaviour
{
    public GameObject[] customerObjs;
    public Transform[] customerQueuePoints;
    public Transform[] customerCollectPoints;
    public Vector2 customerStartPoint;
    float timer = 0, customerSpawnRate;
    int curCustomer, totalCustomers, minRequests, maxRequests;
    public float textTimer;
    public float waitDelay;
    public TMP_Text orderText;


    List<CustomerAgent> curActive = new List<CustomerAgent>();
    List<CustomerAgent> curWaiting = new List<CustomerAgent>();
    Queue<CustomerAgent> unusedAgents = new Queue<CustomerAgent>();

    bool curRequestTyping = false;
    bool curRecieveTyping = false;
    bool day = false;
    private void Start()
    {
        foreach (GameObject obj in customerObjs) 
        {
            unusedAgents.Enqueue(obj.GetComponent<CustomerAgent>());
            obj.SetActive(false);
        }
    }

    private void Update()
    {
        if (day)
        {
            timer += Time.deltaTime;

            if (timer > customerSpawnRate && curCustomer < totalCustomers)
            {
                timer = 0;
                SpawnCustomer();
            }
        }
    }

    void SpawnCustomer() 
    {
        Debug.Log("spawnCustomer");
        int numRequests = Random.Range(minRequests, maxRequests + 1);
        List<int> mix = new List<int>();

        for (int i = 0; i < numRequests; i++)
        {
            int rand = Random.Range(0, ImportantInfo.levelsNumIngredients[ImportantInfo.level]);
            mix.Add(rand);
        }

        CustomerAgent cur = unusedAgents.Dequeue();
        cur.SetTarget(customerQueuePoints[curActive.Count].position);
        cur.SetMix(mix);
        curActive.Add(cur);
        cur.gameObject.SetActive(true);
        curCustomer++;
    }
    void UpdatePositions() 
    {
        for (int i = 0; i < curActive.Count; i++) 
        {
            curActive[i].SetTarget(customerQueuePoints[i].position);
        }

        for (int i = 0; i < curWaiting.Count; i++) 
        {
            curWaiting[i].SetTarget(customerCollectPoints[i].position);
        }
    }

    public void StartDay() 
    {
        totalCustomers = ImportantInfo.numCustomers[ImportantInfo.level];
        minRequests = ImportantInfo.levelsRequestMin[ImportantInfo.level];
        maxRequests = ImportantInfo.levelsRequestMax[ImportantInfo.level];
        customerSpawnRate = ImportantInfo.customerSpawnRate[ImportantInfo.level];
        day = true;
        timer = customerSpawnRate - 2;
    }
    void EndDay() 
    {
        ImportantInfo.level++;
    }

    public void StartCustomerRequest() 
    {
        if (!curRequestTyping && curActive.Count > 0 && !curActive[0].CheckDist()) 
        {
            Debug.Log("StartCustomer");
            StartCoroutine(CustomerRequest());
        }
    }

    IEnumerator CustomerRequest() 
    {
        curRequestTyping = true;
        CustomerAgent agent = curActive[0];
        curActive.RemoveAt(0);
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int i in agent.requestedMix) 
        {
            if (!count.ContainsKey(i)) 
            { 
                count.Add(i, 0);
            }

            count[i]++;
            string text = "";
            if (count[i] == 1)
            {
                text = IngredientsContainer.instance.ingreScriptables[i].requestDescirption;
            } else
            {
                text = IngredientsContainer.instance.ingreScriptables[i].extraRequestDesciption;
            }


            foreach (char c in text) 
            {
                orderText.text += c;
                yield return new WaitForSeconds(textTimer);
            }
            orderText.text += "\n";
        }

        
        
        yield return new WaitForSeconds(waitDelay);
        curWaiting.Add(agent);
        UpdatePositions();
        orderText.text = "";
        curRequestTyping = false;
    }

    public void StartRecievePotion(List<int> mix) 
    {
        if (!curRecieveTyping && curWaiting.Count > 0 && !curWaiting[0].CheckDist()) 
        {
            StartCoroutine(RecievePotion(mix));
        }
    }


    IEnumerator RecievePotion(List<int> mix) 
    {
        curRecieveTyping = true;
        CustomerAgent agent = curWaiting[0];
        curWaiting.RemoveAt(0);


        yield return 0;
        curRecieveTyping = false;
    }

}
