using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int m_PlayerNumber = 1;
    public float m_Speed = 9f;
    public float m_TurnSpeed = 150f;

    private string m_MovementForward; //vertical axis 
    private string m_Turning; //horizontal axis
    
    private Rigidbody m_Rigidbody;
    private float m_ForwardInputValue;
    private float m_TurnInputValue;

    private void Awake(){
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable(){
        m_Rigidbody.isKinematic = false;
        m_ForwardInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_MovementForward = "Vertical" + m_PlayerNumber;
        m_Turning = "Horizontal" + m_PlayerNumber; 
    }

    // Update is called once per frame
    void Update()
    {
        m_ForwardInputValue = Input.GetAxis(m_MovementForward);
        m_TurnInputValue = Input.GetAxis(m_Turning);  
    }

    private void FixedUpdate(){
        MoveForward();
        Turn();
    }
    //forward backwards
    private void MoveForward(){
        Vector3 movementFront = transform.forward * m_ForwardInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movementFront); 
    }
    //Turn
    private void Turn(){
            float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

            Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

            m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
    }

}
