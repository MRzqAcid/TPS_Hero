using UnityEngine;

public class ItemBehavior : MonoBehaviour
{

    public GameBehavior GameManager;

    private void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Item collected!");

            if (GameManager != null) GameManager.Items += 1;
        }
    }
}