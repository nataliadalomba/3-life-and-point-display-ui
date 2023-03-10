using System;
using System.Collections;
using UnityEngine;

public class GridMovement : MonoBehaviour {
    public Coroutine movePlayerCoroutine;

    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float forwardBoundary = 13f;
    [SerializeField] private float leftBoundary = -13f;
    [SerializeField] private float backBoundary = -13f;
    [SerializeField] private float rightBoundary = 13f;

    private bool isMoving;

    //time it takes for player to move from originalPosition to targetPosition. In seconds (so 1/5th of a second)
    private float timeToMove = 0.2f;

    void Update() {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) StartMove(Vector3.forward);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) StartMove(Vector3.left);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) StartMove(Vector3.back);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) StartMove(Vector3.right);
    }

    public bool StartMove(Vector3 direction) {
        if (isMoving) return false;
        movePlayerCoroutine = StartCoroutine(MovePlayer(direction));
        return true;
    }

    private IEnumerator MovePlayer(Vector3 direction) {
        isMoving = true;

        float elapsedTime = 0;

        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = originalPosition + direction;

        if (ValidateGridPosition(targetPosition) == targetPosition) {
            while (elapsedTime < timeToMove) {
                transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
        transform.position = ValidateGridPosition(targetPosition);

        isMoving = false;
    }

    public void stopMovePlayer() {
        StopCoroutine(movePlayerCoroutine);
    }

    public void startMovePlayer() {
        StartCoroutine(MovePlayer(this.transform.position));
    }

    private Vector3 ValidateGridPosition(Vector3 position) {
        if (position.x > rightBoundary) {
            position.x = rightBoundary;
        } else if (position.x < leftBoundary) {
            position.x = leftBoundary;
        } else if (position.z > forwardBoundary) {
            position.z = forwardBoundary;
        } else if (position.z < backBoundary) {
            position.z = backBoundary;
        }
        return position;
    }
}
