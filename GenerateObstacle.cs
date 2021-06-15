using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacle : MonoBehaviour
{
    [SerializeField] GameObject knife;
    float minPosx = -2.2f, maxPosY = 2.2f;
    int gettimer = 0;
    PlayerMove speedManager;

    void Awake()
    {
        speedManager = GameObject.FindObjectOfType<PlayerMove>();
        gettimer = speedManager.timer;
        StartCoroutine(StartPouring());
    }
    void Update()
    {
        gettimer = speedManager.timer;
    }
    IEnumerator StartPouring()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        GameObject weapon = Instantiate(knife);
        float xPos = Random.Range(minPosx, maxPosY);
        weapon.transform.position = new Vector2(xPos, transform.position.y);
        if (gettimer > 10)
        {
            weapon = Instantiate(knife);
            xPos = Random.Range(minPosx, maxPosY);
            weapon.transform.position = new Vector2(xPos, transform.position.y);
        }
        if (gettimer > 40)
        {
            weapon = Instantiate(knife);
            xPos = Random.Range(minPosx, maxPosY);
            weapon.transform.position = new Vector2(xPos, transform.position.y);
        }
        StartCoroutine(StartPouring());
    }
}
