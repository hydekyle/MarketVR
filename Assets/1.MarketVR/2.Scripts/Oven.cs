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
        for (var x = 0; x < bakeableList.Count; x++) bakeableList[x].bakedPoints += bakePotency;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bakeable"))
        {
            bakeableList.Add(other.GetComponent<Bakeable>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("bakeable"))
        {
            bakeableList.Remove(other.GetComponent<Bakeable>());
        }
    }
}
