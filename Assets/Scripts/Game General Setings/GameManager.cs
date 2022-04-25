using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Vector3 startPosition;
    public Vector3 startRotation;
    public GameObject CarPrefab;
    public GameObject Camera;
    public GameSceneLoader GameSceneLoader;

    [Header("Set Dynamically")]
    public GameObject car;

    public float ElapsedTime { get; private set; }
    public bool Running { get; private set; } = false;
    public bool Paused { get; private set; } = false;
    public bool Finished { get; private set; } = false;

    private Rigidbody _carRigidBody;
    private PlayerCameraController _playerController;


    private void Start()
    {
        Cursor.visible = false;
        _playerController = Camera.GetComponent<PlayerCameraController>();

        car = Instantiate(CarPrefab);

        _carRigidBody = car.GetComponent<Rigidbody>();
        _carRigidBody.isKinematic = true;

        SetStartPosition();
    }

    public void StartGame()
    {
        ElapsedTime = 0;
        Running = true;
        Finished = false;
        SetStartPosition();

        _carRigidBody.isKinematic = false;
    }

    public void FinishGame()
    {
        Running = false;
        Finished = true;
        _carRigidBody.isKinematic = true;
    }

    private void SetStartPosition()
    {
        Transform carTransform = car.GetComponent<Transform>();
        carTransform.position = startPosition;
        carTransform.rotation = Quaternion.Euler(startRotation);
        _playerController.FollowPlayer(car);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Running && !Paused)
        {
            ElapsedTime += Time.deltaTime;
        }
    }

    public void PauseGame()
    {
        Paused = true;
        _carRigidBody.isKinematic = true;
    }

    public void ContinueGame()
    {
        Paused = false;
        _carRigidBody.isKinematic = false;
    }

    public void MainMenu()
    {
        GameSceneLoader.LoadMainMenu();
    }

}
