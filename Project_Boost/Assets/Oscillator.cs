using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 0, 0);
    // [Range(0, 1)] [SerializeField] float movementFactor;
    float movementFactor; // 0 not moved, 1 fully moved

    [SerializeField] float period = 2f;

    Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } // protect against period is 0, Epsilon - smallest value that a float can have different from zero

        float cycles = Time.time / period; // grows continually from 0
        const float tau = Mathf.PI * 2; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); // from -1 to 1

        movementFactor = rawSinWave / 2f + 0.5f; // from 0 to 1

        Vector3 offset = movementVector * movementFactor;

        transform.position = startingPosition + offset;
    }
}
