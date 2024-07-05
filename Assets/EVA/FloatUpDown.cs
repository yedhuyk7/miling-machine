using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUpDown : MonoBehaviour
{
   public float amplitude = 0.5f; // Height of the floating movement
    public float frequency = 1f;   // Speed of the floating movement

    private Vector3 startPos;

    void Start()
    {
        // Store the starting position
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;

        // Apply the new position to the object
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
