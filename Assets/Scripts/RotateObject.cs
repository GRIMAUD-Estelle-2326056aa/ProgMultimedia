using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    [SerializeField] Vector3 m_AngleSpeed;
    [SerializeField] Space m_Space;
    [SerializeField] bool m_Randomize;
    
    // Start is called before the first frame update
    void Start()
    {
        if (m_Randomize) transform.Rotate(m_AngleSpeed * Random.Range(0, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(m_AngleSpeed * Time.deltaTime, m_Space);
    }
}