using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float moveRadius = 4.5f; // how far the ship can drift from center

    private CharacterController controller;
    private Vector3 localOffset; // tracked offset from the ring's center line

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical"); // up/down

        Vector3 input = new Vector3(h, v, 0f) * speed * Time.deltaTime;
        Vector3 candidate = localOffset + input;

        // clamp drift to a circle so player can't fly off the ring
        if (candidate.magnitude > moveRadius)
            candidate = candidate.normalized * moveRadius;

        Vector3 delta = candidate - localOffset;
        localOffset = candidate;

        controller.Move(delta);
    }
}