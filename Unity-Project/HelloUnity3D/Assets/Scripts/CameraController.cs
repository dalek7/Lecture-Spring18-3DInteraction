using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
	public bool toFollowObject;
    // 초기화 할때 한번 실행됨
    void Start()
    {
        offset = transform.position - player.transform.position;
		toFollowObject = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
		if(toFollowObject)
        transform.position = player.transform.position + offset;
    }
}
