using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackAndDino
{
    public Cinemachine.CinemachineSmoothPath path;
    public Transform targetPrefab;
}


public class camTrackSwitcher : MonoBehaviour
{
    [SerializeField] Cinemachine.CinemachineDollyCart cart;
    [SerializeField] Cinemachine.CinemachineVirtualCamera virCam;
    public Cinemachine.CinemachineSmoothPath startPath;
    public TrackAndDino[] alterPath;

    void Start()
    {
        DoReset();
    }

    void DoReset()
    {
        StopAllCoroutines();
        cart.m_Path = startPath;
        StartCoroutine(ChangeTrack());
    }

    IEnumerator ChangeTrack()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        cart.m_Position = Random.Range(0, 2);
        cart.m_Speed = Random.Range(.2f, .6f);

        var path = alterPath[Random.Range(0, alterPath.Length)];
        cart.m_Path = path.path;
        virCam.LookAt = path.targetPrefab;
        StartCoroutine(ChangeTrack());

    }


}
