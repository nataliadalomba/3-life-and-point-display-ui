using Unity.VisualScripting;
using UnityEngine;

public class Respawn : MonoBehaviour {
    private Transform player;
    private Transform respawnPoint;

    private void Start() {
        player = FindObjectOfType<Player>().transform;
        respawnPoint = FindObjectOfType<RespawnPoint>().transform;
    }

    private void OnTriggerEnter(Collider other) {
        Player p = other.GetComponent<Player>();
        if (p != null) {
            FindObjectOfType<GridMovement>().stopMovePlayer();
            player.transform.position = respawnPoint.transform.position;
            ScoreManager.instance.SubtractLife();
        if (ScoreManager.instance.PlayerDeath()) return;
            FindObjectOfType<GridMovement>().startMovePlayer();
        }
    }
}
