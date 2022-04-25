using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private GameObject _player;
    public Vector3 CameraOffset = new Vector3(0f, 3f, -5f);
    public Quaternion CameraRotation = Quaternion.Euler(30f, 0f, 0f);

    private void Update()
    {
        if (_player != null)
        {
            transform.parent = _player.transform;
            transform.localPosition = CameraOffset;
            transform.localRotation = CameraRotation;
        }
    }

    public void FollowPlayer(GameObject player)
    {
        _player = player;
    }
}
