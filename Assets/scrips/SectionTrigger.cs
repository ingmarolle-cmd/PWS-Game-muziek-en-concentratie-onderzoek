using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;

    private Transform spawnPoint;
    private bool hasTriggered = false;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("RoadSpawnPoint").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;

            GameObject newSection = Instantiate(
                roadSection,
                spawnPoint.position,
                spawnPoint.rotation
            );

            newSection.name = "RoadSection";
        }
    }
}