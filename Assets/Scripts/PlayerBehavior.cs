using UnityEngine;

public class PlayerBehavior : MonoBehaviour


{

    private float _vInput;
    private float _hIutput;
    private Rigidbody _rb;

    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;

    public float jumpVelocity=5f;
    private bool _isJumping;

    //Ground check Vars
    public bool IsOnGround = true;
    public float GroundCheckRadius = 0.3f;
    public LayerMask GroundLayer;

    //Shooting Vars
    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _isShooting;



    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _vInput = Input.GetAxis("Vertical") * moveSpeed;
        _hIutput = Input.GetAxis("Horizontal") * rotateSpeed;
        //_isJumping |= Input.GetKeyDown(KeyCode.Space);

        _isShooting |= Input.GetKeyDown(KeyCode.F);

        IsOnGround = Physics.CheckSphere(transform.position, GroundCheckRadius, GroundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            _isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + transform.forward * _vInput * Time.deltaTime);
        Quaternion angelRot = Quaternion.Euler(Vector3.up *  _hIutput *  Time.deltaTime);
        _rb.MoveRotation(_rb.rotation * angelRot);

        if (_isJumping)
        {
            Debug.Log("Jump");
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            _isJumping = false;
        }

        if (_isShooting)
        {
            Vector3 spawnPos = transform.position + transform.forward * 1f;
            GameObject newBullet = Instantiate(Bullet, spawnPos, this.transform.rotation);
            Rigidbody bullletRb = newBullet.GetComponent<Rigidbody>();
            bullletRb.linearVelocity = transform.forward * BulletSpeed;
            _isShooting = false;
        }


    }




}
