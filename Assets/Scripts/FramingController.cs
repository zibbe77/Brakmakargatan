using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FramingController : MonoBehaviour
{

    [SerializeField]
    PlayerController player1;

    [SerializeField]
    PlayerController player2;

    [Header("Camera position/panning")]

    [SerializeField]
    bool cameraFollowX;
    [SerializeField]
    bool cameraFollowY;

    [Header("Camera size/zooming")]

    [SerializeField]
    float minCameraWidth = 5;
    [SerializeField]
    float maxCameraWidth = 10;

    [SerializeField]
    float cameraMargin = 1;

    private float verticalOffset;

    void Start()
    {
        Vector3 midPoint = CharacterMidpoint();
        verticalOffset = this.transform.position.y - midPoint.y;

        KeepCameraCentered();
        KeepCharactersInFrame(true);
    }

    void Update()
    {
        KeepCameraCentered();
        KeepCharactersInFrame();

    }

    void KeepCameraCentered()
    {
        Vector3 midPoint = CharacterMidpoint();

        transform.position = new Vector3(
            midPoint.x* (cameraFollowX? 1 : 0),
            (midPoint.y + verticalOffset) * (cameraFollowY? 1 : 0),
            transform.position.z
            );
    }

    void KeepCharactersInFrame(bool force = false)
    {
        float cameraEdge = this.GetComponent<Camera>().orthographicSize * this.GetComponent<Camera>().aspect;

        float p1DistanceFromCamCenter = Mathf.Abs(this.transform.position.x - player1.transform.position.x);

        float p2DistanceFromCamCenter = Mathf.Abs(this.transform.position.x - player2.transform.position.x);

        float moarDistance = cameraMargin + Mathf.Max(p1DistanceFromCamCenter, p2DistanceFromCamCenter);


        if (moarDistance < maxCameraWidth && moarDistance > minCameraWidth || force)
        {
            this.GetComponent<Camera>().orthographicSize = moarDistance / this.GetComponent<Camera>().aspect;
        }
    }

    Vector3 CharacterMidpoint()
    {
        return (player1.gameObject.transform.position + player2.gameObject.transform.position) * 0.5f;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(CharacterMidpoint(), 1f);
    }
}
