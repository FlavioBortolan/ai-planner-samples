using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int m_cols;
    public int m_rows;
    public float Dist;

    public Platform m_Platform;

    public Cube m_Cube;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < m_rows; i++)
        {
            for (int j = 0; j < m_cols; j++)
            {
                var platform = Instantiate(m_Platform, new Vector3(j*Dist, 0, i*Dist), Quaternion.identity, transform);
            }
        }

        var Cube = Instantiate(m_Cube, new Vector3(0, 0, 0), Quaternion.identity, transform);
    }

    public IEnumerator Move(GameObject character, GameObject destination)
    {
        character.transform.LookAt(destination.transform);

        while (Vector3.Distance(character.transform.position, destination.transform.position) > 0.1f)
        {
            character.transform.position = Vector3.Lerp(character.transform.position, destination.transform.position, 12 * Time.deltaTime);
            yield return null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
