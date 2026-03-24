using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private int amount = 5;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Build(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) Build(2);
    }

    void Build(int type)
    {
        Clear();

        for (int i = 0; i < amount; i++)
        {
            if (prefabs.Length == 0) return;

            int index = Random.Range(0, prefabs.Length);
            Vector3 pos = Vector3.zero;

            if (type == 1)
            {
                pos = new Vector3(i * 5, 0, 0);
            }
            else
            {
                pos = new Vector3(i * 4, i * 1.5f, 0);
            }

            Instantiate(prefabs[index], pos, Quaternion.identity);
        }
    }

    void Clear()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject obj in objects) Destroy(obj);
    }
}
