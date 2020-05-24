using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public CharacterController controller;

    [SerializeField]
    float moveSpeed = 4f;
    float gravity = -9.81f;
    int count;

    public Text displayText;
    public GameObject advanceLevel;
    public GameObject winZone;
    public GameObject winText;

    Vector3 velocity;
    Vector3 forward, right;


    void Start()
    {
        count = 0;
        SetDisplayText();

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update()
    {
        if (Input.anyKey)
            Move();

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void Move()
    {
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Collectible")
        {     
           col.gameObject.SetActive(false);
            count = count + 1;
            SetDisplayText();

            FindObjectOfType<AudioManager>().Play("Collectible");
        }

        if (col.gameObject.tag == "Win")
        {
            FindObjectOfType<AudioManager>().Play("Congratulations");
            SetCongratulationsText();
        }
    }

    private void SetDisplayText()
    {
        displayText.text = "" + count.ToString();
        if (count >= 3)
        {
            advanceLevel.SetActive (true);
            winZone.SetActive(true);

        }
    }

    private void SetCongratulationsText()
    {
        advanceLevel.SetActive (false);
        winText.SetActive(true);

    }
}
