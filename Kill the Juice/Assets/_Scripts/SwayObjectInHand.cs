using UnityEngine;

public class SwayObjectInHand : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public Vector3 posVel, posOffset, defaultPos;
    public float posSpeed;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        MoveObjectEffect();
    }

    void MoveObjectEffect()
    {
        Vector3 offset = playerMovement.FindVelRelativeToLook() * posOffset;
        float fallSpeed = playerMovement.GetFallSpeed * posOffset.y;
        Vector3 desiredPos = defaultPos - new Vector3(offset.x, fallSpeed, offset.y);
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, desiredPos, ref posVel, posSpeed);
    }
}
