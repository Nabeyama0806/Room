using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReScale : Props
{
    [SerializeField] Vector3 m_scale;

    protected override void StartExecute()
    {
        transform.localScale = m_scale;
    }
}
