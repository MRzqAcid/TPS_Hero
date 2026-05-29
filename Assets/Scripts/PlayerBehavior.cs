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

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _vInput = Input.GetAxis("Vertical") * moveSpeed;
        _hIutput = Input.GetAxis("Horizontal") * rotateSpeed;
        _isJumping |= Input.GetKeyDown(KeyCode.Space);
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
    }




}
