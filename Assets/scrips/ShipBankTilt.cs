using UnityEngine;

public class ShipBankTilt : MonoBehaviour
{
    public float maxBankAngle = 35f;   // how far the ship rolls at full input
    public float bankSpeed = 6f;       // how quickly it eases into/out of the roll

    public float maxPitchAngle = 10f;  // optional: nose tilts up/down too
    public float pitchSpeed = 10f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Quaternion targetRotation = Quaternion.Euler(
            vertical * -maxPitchAngle,   // pitch: nose up when climbing
            0f,
            horizontal * -maxBankAngle   // roll: banks into the turn
        );

        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            targetRotation,
            bankSpeed * Time.deltaTime
        );
    }
}