using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Animator aishaAnimatorController;
    [SerializeField] private Dialogue dialog;
    [SerializeField] private SceneController sceneController;
    private float moveVelocity;
    private Rigidbody2D rb;
    private int idleRightAnimationParameter = Animator.StringToHash("idleRight");
    private int idleLeftAnimationParameter = Animator.StringToHash("idleLeft");
    private int moveRightAnimationParameter = Animator.StringToHash("moveRight");
    private int moveLeftAnimationParameter = Animator.StringToHash("moveLeft");
    

    private void Awake()
    {
        rb =  GetComponentInChildren<Rigidbody2D>();    
    }

    private void Update()
    {
        if (GameState.isPlaying && GameState.canMove)
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            aishaAnimatorController.SetBool(idleLeftAnimationParameter, false);
            aishaAnimatorController.SetBool(idleRightAnimationParameter, false);
            aishaAnimatorController.SetBool(moveLeftAnimationParameter, false);
            aishaAnimatorController.SetBool(moveRightAnimationParameter, true);
            rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            aishaAnimatorController.SetBool(idleLeftAnimationParameter, false);
            aishaAnimatorController.SetBool(idleRightAnimationParameter, false);
            aishaAnimatorController.SetBool(moveRightAnimationParameter, false);
            aishaAnimatorController.SetBool(moveLeftAnimationParameter, true);
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            aishaAnimatorController.SetBool(moveRightAnimationParameter, false);
            aishaAnimatorController.SetBool(idleRightAnimationParameter, true);
            rb.velocity = Vector2.zero;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            aishaAnimatorController.SetBool(moveLeftAnimationParameter, false);
            aishaAnimatorController.SetBool(idleLeftAnimationParameter, true);
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "TriggerDialog")
        {
            GameState.isPlaying = false;
            GameState.canMove = false;
            rb.velocity = Vector2.zero;
            aishaAnimatorController.SetBool(moveRightAnimationParameter, false);
            aishaAnimatorController.SetBool(moveLeftAnimationParameter, false);
            aishaAnimatorController.SetBool(idleRightAnimationParameter, true);
            dialog.StartDialogue();
            Destroy(collider.gameObject);
        }

        if (collider.name == "TriggerCutscene")
        {
            GameState.isPlaying = false;
            GameState.canMove = false;
            rb.velocity = Vector2.zero;
            aishaAnimatorController.SetBool(moveRightAnimationParameter, false);
            aishaAnimatorController.SetBool(moveLeftAnimationParameter, false);
            aishaAnimatorController.SetBool(idleRightAnimationParameter, true);
            sceneController.StartCutscene();
            Destroy(collider.gameObject);
        }
    }
}
