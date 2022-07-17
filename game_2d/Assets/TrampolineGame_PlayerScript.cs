using UnityEngine;

public class TrampolineGame_PlayerScript : MonoBehaviour
{
    float playerMoveSpeed = 12;
    float trampolineMoveSpeed = 8;
    float jumpSpeed = 3;

    //true if the player is currently performing a high jump
    bool jumpHigh = false;

    //true if the player is on the way down from a high jump
    bool hasJumped = true;

    //variables for the outer edges of the trampoline
    float trampolineStart;
    float trampolineEnd;

    //keep track of which phase the jump is in, 0 = start, Pi / jumpspeed = end
    float jumpTime = 0;

    [SerializeField] GameObject trampoline;

    //true if the trampoline should be moving right
    bool hitEdge = false;

    //sfx
    [SerializeField] private AudioClip jumpsound;

    void Update()
    {
        float move = 0;
        if (Input.GetKey(KeyCode.A))
        {
            move -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += 1;
        }

        //update which phase of the jump the player is in
        jumpTime += Time.deltaTime;

        //if the player is hitting the trampoline, reset the jump
        if (jumpTime > Mathf.PI / jumpSpeed && transform.position.x > trampolineStart && transform.position.x < trampolineEnd)
        {
            jumpTime = 0;

            //if the player was in a high jump, return to normal jumps
            if (hasJumped)
            {
                jumpHigh = false;
            }

            SoundManager.instance.PlaySound(jumpsound); //plays jump sound
        }

        //moves the player in a sine wave, to simulate a jump. moves higher if high jump is enabled
        if (!jumpHigh)
        {
            transform.position = new Vector3(transform.position.x + move * Time.deltaTime * playerMoveSpeed, Mathf.Sin(jumpTime * jumpSpeed) * 4 + 1.5f, transform.position.z);
            
        }
        else
        {
            transform.position = new Vector3(transform.position.x + move * Time.deltaTime * playerMoveSpeed, Mathf.Sin(jumpTime * jumpSpeed) * 6 + 1.5f, transform.position.z);
            
        }
        

        //removes player if he exits the screen
        if (transform.position.y < -0.5f)
        {
            Destroy(gameObject);
        }
        //if the player is within reach and presses space, trigger a high jump
        else if (transform.position.y < 2.5f && Input.GetKeyDown(KeyCode.Space))
        {
            jumpHigh = true;
            hasJumped = false;
        }

        //if the player is above y = 5, it means they've just performed a high jump
        if (transform.position.y > 5)
        {
            hasJumped = true;
        }

        //move trampoline around
        if (!hitEdge)
        {
            trampoline.transform.position = new Vector3(trampoline.transform.position.x + trampolineMoveSpeed * Time.deltaTime, 0.75f, 0);
        }
        else
        {
            trampoline.transform.position = new Vector3(trampoline.transform.position.x - trampolineMoveSpeed * Time.deltaTime, 0.75f, 0);
        }
        if (trampoline.transform.position.x < 2.5f)
        {
            hitEdge = false;
        }
        else if (trampoline.transform.position.x > 16.7f)
        {
            hitEdge = true;
        }

        //set new trampoline edge coordinates
        trampolineStart = trampoline.transform.position.x - 2;
        trampolineEnd = trampoline.transform.position.x + 2;
    }
}
