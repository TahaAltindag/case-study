using System.Collections.Generic;
using Simofun.DevCaseStudy.Unity;
using Simofun.DevCaseStudy.Unity.TapDragToSort.Scripts;
using UnityEngine;
using Box = Simofun.DevCaseStudy.Unity.TapDragToSort.Scripts.Box;

public class GameController : MonoBehaviour
{
    public Box[] boxes;
    public GameObject[] sweetPrefabs;

    private void Start()
    {
        // Initialize boxes and sweets
        InitializeSweets();
        CheckForCompletion();
    }

    private void InitializeSweets()
    {
        List<Placeholder> placeholders = new List<Placeholder>();

        // Collect all placeholders from all boxes
        foreach (var box in boxes)
        {
            placeholders.AddRange(box.GetComponentsInChildren<Placeholder>());
        }

        List<Sweet> sweets = new List<Sweet>();

        // Instantiate sweets from prefabs (4 of each type)
        foreach (var prefab in sweetPrefabs)
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject sweetObj = Instantiate(prefab);
                Sweet sweet = sweetObj.GetComponent<Sweet>();
                sweets.Add(sweet);
            }
        }

        // Shuffle the sweets list
        ShuffleList(sweets);

        // Assign each sweet to a random placeholder
        for (int i = 0; i < sweets.Count; i++)
        {
            placeholders[i].SetSweet(sweets[i]);
            sweets[i].transform.SetParent(placeholders[i].transform);
            sweets[i].transform.localPosition = Vector3.zero;
        }
    }

    private void ShuffleList<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
        }
    }

    public void CheckForCompletion()
    {
        foreach (var box in boxes)
        {
            if (box.IsComplete())
            {
                Debug.Log("Box is complete with " + box.GetComponent<Placeholder>().Sweet.Name);
            }
        }
    }
}