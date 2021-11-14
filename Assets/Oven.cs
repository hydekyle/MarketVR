using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    List<Bakeable> bakeableList = new List<Bakeable>();
    public int bakeDelaySeconds = 1;
    public float bakePotency = 1f;
    float _nextBakeTime = 0f;

    void FixedUpdate()
    {
        if (Time.time > _nextBakeTime)
        {
            _nextBakeTime = Time.time + bakeDelaySeconds;
            Bake();
        }
    }

    void Bake()
    {
        bakeableList.ForEach(element => element.bakedPoints += bakePotency);
    }

    private void OnTriggerEnter(Collider2D other)
    {
        if (other.CompareTag("bakeable"))
        {
            bakeableList.Add(other.GetComponent<Bakeable>());
        }
    }

    private void OnTriggerExit(Collider2D other)
    {
        if (other.CompareTag("bakeable"))
        {
            bakeableList.Remove(other.GetComponent<Bakeable>());
        }
    }
}
