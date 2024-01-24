using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COR : MonoBehaviour
{
    [SerializeField] float time = 3;
    [SerializeField] bool go = false;
    Coroutine timercoroutine;

    // Start is called before the first frame update
    void Start()
    {
       timercoroutine = StartCoroutine(Timer(time)); 
       StartCoroutine("StoryTime"); 
       StartCoroutine("WaitAction"); 
    }

    // Update is called once per frame
    void Update()
    {
        //time -= Time.deltaTime;
        //if(time <= 0)
        //{
        //    time = 4;
        //    print("hello");
        //}
    }


    IEnumerator Timer(float time)
    {
        while (true )
        {
        yield return new WaitForSeconds(time);
        print("tick");

        }
        //yield return null;
    }
    IEnumerator StoryTime()
    {
        print("hello");
        yield return new WaitForSeconds(1);
        print("welcome to the new world");
        yield return new WaitForSeconds(1);
        print("Time to die!");

        StopCoroutine(timercoroutine);
        yield return null;
    } 
    IEnumerator WaitAction()
    {
        yield return new WaitUntil(() => go);
        print("go");
        yield return null;
    }



}
