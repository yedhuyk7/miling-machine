using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject eva;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player || other.gameObject == eva)
        {
            StartCoroutine(Teleport());
        }
    }

    private IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);

        // Set the player's position and rotation
        player.transform.position = new Vector3(-3.05f, 0.953f, 5.37f);
        player.transform.rotation = Quaternion.Euler(0, 0, 0);

        // Set EVA's position and rotation
        eva.transform.position = new Vector3(-5.75793f, 1.3f, 10.38964f);
        eva.transform.rotation = Quaternion.Euler(0, 158.731f, 0);
    }
}
