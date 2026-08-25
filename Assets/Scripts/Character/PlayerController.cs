using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    Animator animator;
    CharacterController controller;
    [SerializeField] float movX, movZ; // muestra el movimiento de las direcciones Z y X del jugador.
    Vector3 movement;
    public enum playerState
    {
        Idle,
        Walking,
        Running
    }
    playerState currentState;
    public float Speed; //velocidad de movimiento.

    public float RotSpeed;
    public float SprintSpeed; //velocidad de movimiento cuando corre.
    public ParticleSystem EfectoCorrer;

    private void Awake() 
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        currentState = playerState.Idle;
        Cursor.lockState = CursorLockMode.Locked; // Desaparece el cursor de la pantalla para asegurar un uso más cómodo
    }

 
    void Update()
    {
        Callinputs();
        MovePlayer();
    }



    // Llama esta funcion para agregarle los inputs predeterminados de unity a las variables
    void Callinputs()
    {
        movX = Input.GetAxisRaw("Horizontal");
        movZ = Input.GetAxisRaw("Vertical");
    }

    //realiza el movimiento del jugador segun el estado en el que este.
    void MovePlayer()
    {
        // si se movx y movz se presionan lo detecta y cambia el estado 
        // y gracias al mathF.abs no importa si es negativo
        if(Mathf.Abs(movX) > 0.3f || Mathf.Abs(movZ) > 0.01f)
        {
            currentState = playerState.Walking;

            if(Input.GetKey("left shift"))
                currentState = playerState.Running;
        }
        else
        {
            currentState = playerState.Idle;
        }

        //cambio entre estados
        switch(currentState)
        {

         case playerState.Idle:
                
                EfectoCorrer.Stop();
                animator.SetBool("Running", false);
                animator.SetBool("Walking", false);

         break;

         case playerState.Walking:
                
                EfectoCorrer.Stop();
                animator.SetBool("Running", false);
                animator.SetBool("Walking", true);
                
                ApplyMove(Speed);
                
         break;

         case playerState.Running:
                
                EfectoCorrer.Play();
                animator.SetBool("Running", true);
                animator.SetBool("Walking", false);

                //Por el momento se pone el speed y se multiplica
                ApplyMove(Speed * SprintSpeed);

         break;   

         default:

            currentState = playerState.Idle;

         break;
        }
    }

    // Aplica el movimiento segun el tipo de estado deljugador
    void ApplyMove(float playerSpeed)
    {            
        movement = new Vector3(movX,0,movZ).normalized;

        //movement.Normalize();

        if(movement.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(-movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,RotSpeed * Time.deltaTime);
        }
            

        Vector3 movexz = movement * (playerSpeed * Time.deltaTime); 


        controller.Move(movexz);
        
    }
}
