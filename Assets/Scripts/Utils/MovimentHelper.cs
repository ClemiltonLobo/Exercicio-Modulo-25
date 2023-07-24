using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentHelper : MonoBehaviour
{
    public List<Transform> positions;
    public float duration = 1f;
    public bool useRandomPosition = false;
    public int[] initialPositions;

    private int _index = 0;

    private void Start()
    {
        if (useRandomPosition)
        {
            // Usar uma posição aleatória para cada inimigo
            int randomIndex = UnityEngine.Random.Range(0, positions.Count);
            transform.position = positions[randomIndex].position;
        }
        else if (initialPositions.Length > 0)
        {
            // Usar as posições definidas no Inspector
            int clampedIndex = Mathf.Clamp(_index, 0, initialPositions.Length - 1);
            transform.position = positions[initialPositions[clampedIndex]].position;
        }
        else
        {
            // Usar a primeira posição da lista como padrão
            transform.position = positions[0].position;
        }
        NextIndex();
        StartCoroutine(StartMoviment());
    }

    void NextIndex()
    {
        _index++;
        if (_index >= positions.Count) _index = 0;
    }
    IEnumerator StartMoviment()
    {
        float time = 0;
        while (true)
        {
            var currentPosition = transform.position;

            while (time < duration)
            {
                transform.position = Vector3.Lerp(currentPosition, positions[_index].transform.position, (time/ duration));
                time += Time.deltaTime;
                yield return null;
            }
            NextIndex();
            time = 0;

            yield return null;
        }
    }
}