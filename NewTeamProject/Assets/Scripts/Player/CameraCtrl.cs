using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public float dist = 10.0f;
    public float height = 10.0f;

    private Transform targetTr;

    // Start is called before the first frame update
    void Start()
    {
        SetCamTarget();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void SetCamTarget()
    {
        targetTr = GameManager.Instance.Inven.gameObject.transform;
    }

    private void FollowPlayer()
    {
        transform.position = targetTr.position - (Vector3.forward * dist) + (Vector3.up * height);
        transform.LookAt(targetTr);
    }
}
