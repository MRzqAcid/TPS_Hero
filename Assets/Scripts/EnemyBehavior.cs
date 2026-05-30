using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player") Debug.Log("Player Detected - Attack!");
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player") Debug.Log("Player out of Range - Resume Patrol!");
    }




}
