using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    public float OnscreenDelay = 3f;
    private void Start()
    {
        Destroy(this.gameObject, OnscreenDelay);
    }



}
