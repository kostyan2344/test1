using UnityEngine;
using UnityEngine.AI;

internal class RagdollController : MonoBehaviour
{

    private Rigidbody[] rbArray;
    private Collider[] colliders;

    [SerializeField]
    private Rigidbody spine;

    private void Awake()
    {
        rbArray = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
        ToggleRagdoll(true);
        bike.death += ToggleRagdoll2;
    }

    private void ToggleRagdoll(bool isActivated)
    {

        foreach (Rigidbody rb in rbArray) rb.isKinematic = isActivated;
        foreach (Collider collider in colliders)
        {
            if (!collider.isTrigger) collider.enabled = !isActivated;
        }
    } 
    private void ToggleRagdoll2(bool isActivated, Collider other)
    {

        foreach (Rigidbody rb in rbArray) rb.isKinematic = isActivated;

        if (!isActivated)
        {
            spine.AddForce((-spine.transform.forward * 10) + (other.transform.forward * 10), ForceMode.Impulse);
        }

        foreach (Collider collider in colliders)
        {
            if (!collider.isTrigger) collider.enabled = !isActivated;
        }
    }
}
