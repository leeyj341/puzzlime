using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneMovement : MonoBehaviour
{
    ItemDropSystem m_sSys;
    MeshRenderer m_sMesh;

    Vector3[] m_ArrNode_Left = new Vector3[5];
    Vector3[] m_ArrNode_Top = new Vector3[5];

    Vector3 m_vecStart;
    Vector3 m_vecDest;

    float m_fT;
    // Start is called before the first frame update
    void Start()
    {
        m_sMesh = gameObject.GetComponent<MeshRenderer>();
        m_sSys = gameObject.GetComponent<ItemDropSystem>();
        for (int i = 0; i < 5; i++)
        {
            m_ArrNode_Left[i] = new Vector3(-80, 100, 80 - 40 * i);
            m_ArrNode_Top[i] = new Vector3(-80 + 40 * i, 100, 80);
        }
    }

    public void AirPlaneStart()
    {
        SetAriplane();

        transform.LookAt(m_vecDest);

        StartCoroutine(FlyAirPlane());
    }

    void SetAriplane()
    {
        int Start = Random.Range(1, 5);
        int StartIndex = Random.Range(1, 5);
        int DestIndex = Random.Range(1, 5);

        switch (Start)
        {
            case 1:
                m_vecStart = m_ArrNode_Left[StartIndex];
                m_vecDest = m_ArrNode_Left[DestIndex];
                m_vecDest.x = -m_vecDest.x;
                break;
            case 2:
                m_vecStart = m_ArrNode_Left[StartIndex];
                m_vecStart.x = -m_vecStart.x;
                m_vecDest = m_ArrNode_Left[DestIndex];
                break;
            case 3:
                m_vecStart = m_ArrNode_Top[StartIndex];
                m_vecDest = m_ArrNode_Top[DestIndex];
                m_vecDest.z = -m_vecDest.z;
                break;
            case 4:
                m_vecStart = m_ArrNode_Top[StartIndex];
                m_vecStart.z = -m_vecStart.z;
                m_vecDest = m_ArrNode_Top[DestIndex];
                break;
        }
        m_fT = 0;
    }

    // Update is called once per frame

    IEnumerator FlyAirPlane()
    {
        m_sMesh.enabled = true;
        while (m_fT < 1)
        {
            m_fT += Time.deltaTime / 10.0f;
            transform.position = Vector3.Lerp(m_vecStart, m_vecDest, m_fT);
            if(Random.Range(0,100) > 97)
                m_sSys.ItemDrop();
            yield return null;
        }
        m_sMesh.enabled = false;
    }
}
