using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{  
     public Transform doorPivot1; // The transform of the first door pivot parent
    public Transform doorPivot2; // The transform of the second door pivot parent
    public Vector3 door1OpenRotation; // The rotation when the first door is open
    public Vector3 door1ClosedRotation; // The rotation when the first door is closed
    public Vector3 door2OpenRotation; // The rotation when the second door is open
    public Vector3 door2ClosedRotation; // The rotation when the second door is closed
    public float openSpeed = 2f; // Speed of opening/closing

    private bool isOpen = false;
    private Quaternion door1OpenQuaternion;
    private Quaternion door1ClosedQuaternion;
    private Quaternion door2OpenQuaternion;
    private Quaternion door2ClosedQuaternion;
    private Coroutine currentCoroutine;
    private bool isChangingState = false; // Prevent rapid state change

    void Start()
    {
        door1OpenQuaternion = Quaternion.Euler(door1OpenRotation);
        door1ClosedQuaternion = Quaternion.Euler(door1ClosedRotation);
        door2OpenQuaternion = Quaternion.Euler(door2OpenRotation);
        door2ClosedQuaternion = Quaternion.Euler(door2ClosedRotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen && !isChangingState)
        {
            isOpen = true;
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            currentCoroutine = StartCoroutine(ChangeDoorState(door1OpenQuaternion, door2OpenQuaternion));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpen && !isChangingState)
        {
            isOpen = false;
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            currentCoroutine = StartCoroutine(ChangeDoorState(door1ClosedQuaternion, door2ClosedQuaternion));
        }
    }

    IEnumerator ChangeDoorState(Quaternion targetRotation1, Quaternion targetRotation2)
    {
        isChangingState = true;
        while (Quaternion.Angle(doorPivot1.localRotation, targetRotation1) > 0.01f || Quaternion.Angle(doorPivot2.localRotation, targetRotation2) > 0.01f)
        {
            doorPivot1.localRotation = Quaternion.Slerp(doorPivot1.localRotation, targetRotation1, Time.deltaTime * openSpeed);
            doorPivot2.localRotation = Quaternion.Slerp(doorPivot2.localRotation, targetRotation2, Time.deltaTime * openSpeed);
            yield return null;
        }
        doorPivot1.localRotation = targetRotation1;
        doorPivot2.localRotation = targetRotation2;
        yield return new WaitForSeconds(0.5f); // Small delay to prevent rapid toggling
        isChangingState = false;
    }
}
