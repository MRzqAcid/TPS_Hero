using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    private GameBehavior _gameManager;

    private int _enemyLives = 3;
    private int EnemyLives
    {
        get { return _enemyLives; }
        set
        {
            _enemyLives = value;
            if (_enemyLives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("EnemyDown!");
            }
        }
    }

    private void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player Detected - Attack!");
            if (_gameManager != null)
            {
                _gameManager.HP -= 2;
                Debug.Log("PlayerHP: " + _gameManager.HP);
            }
        }
           
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            EnemyLives -= 1;
            Debug.Log("Critical hit!! Enemy Lives : " + _enemyLives);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player") Debug.Log("Player out of Range - Resume Patrol!");
    }



}
