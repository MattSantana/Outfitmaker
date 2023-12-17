using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPreviewer : MonoBehaviour
{

    private Animator animator;
    private Vector2[] positions;
    private int currentPosition;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        CreatePositions();
        transform.localPosition = positions[0] = new Vector2(0, -1);      // Down
        UpdatePosition();
    }

    private void CreatePositions()
    {
        positions = new Vector2[4];
        positions[0] = new Vector2(0, -1);      // Down
        positions[1] = new Vector2(-1, 0);      // Left
        positions[2] = new Vector2(0, 1);       // Up
        positions[3] = new Vector2(1, 0);       // Right
    }

    public void RotateLeft()
    {
        if (currentPosition < positions.Length - 1)
        {
            currentPosition++;
        }
        else
        {
            currentPosition = 0;
        }

        UpdatePosition();
    }

    public void RotateRight()
    {
        if (currentPosition > 0)
        {
            currentPosition--;
        }
        else
        {
            currentPosition = positions.Length - 1;
        }

        UpdatePosition();
    }

    private void UpdatePosition()
    {
        animator.SetFloat("lastMoveX", positions[currentPosition].x);
        animator.SetFloat("lastMoveY", positions[currentPosition].y);
    } 
}

