using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float SpeedForce;
    public float GravityForce;
    public float JumpForce;
    [HideInInspector]  
    public bool CanBeDamage;
    [HideInInspector]
    public bool CanGetBonus;
    public float Points;
    public Text PointsText;
    public GameManager GM;

    private bool isGrounded;
    private Rigidbody _rigidbody;
    private float timeToDamage;
    private float timeToGetBonus;




    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.A))
        //{
        //    _rigidbody.AddForce(Vector3.left * SpeedForce);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    _rigidbody.AddForce(Vector3.right * SpeedForce);
        //}

        //_rigidbody.AddForce(Vector3.forward * SpeedForce);

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * SpeedForce * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * SpeedForce * Time.deltaTime;
        }

        if ((Input.GetKeyDown(KeyCode.Space))&& isGrounded==true)
        {

            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

        //transform.position += Vector3.forward * SpeedForce * Time.deltaTime;
        _rigidbody.AddForce(Vector3.down * GravityForce);

        timeToDamage += Time.deltaTime;
        timeToGetBonus += Time.deltaTime;
        if (timeToDamage>=1)
        {
            CanBeDamage = true;
        }

        if (timeToGetBonus >= 1)
        {
            CanGetBonus = true;
        }

        PointsText.text = Points.ToString();

        if (Points<0)
        {
            Debug.Log("kzkz");
            GM.LoseGame();
            Points = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    public void ForbidToDamage()
    {
        CanBeDamage = false;
        timeToDamage = 0;
    }
    public void ForbidToGetBonus()
    {
        CanGetBonus = false;
        timeToGetBonus = 0;
    }
}

