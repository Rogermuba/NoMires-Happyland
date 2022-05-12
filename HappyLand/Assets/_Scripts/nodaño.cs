using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class nodaño : MonoBehaviour
{
    [SerializeField] private float duration = 5.0f; // Duration in seconds

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return; // Exit if the player didn't trigger

        FirstPersonController player = other.GetComponent<FirstPersonController>();
        if (player.isImmune) return; // Exit if the player currently has a potion
        player.isImmune = true;

        StartCoroutine(RemoveImmunity(duration, player));
        transform.position = new Vector3(0, -16, 0); // Hide potion out of bounds while timer ends
    }
    public IEnumerator RemoveImmunity(float delay, FirstPersonController player)
    {
        yield return new WaitForSeconds(delay);
        player.isImmune = false;
        Destroy(gameObject);
    }
}