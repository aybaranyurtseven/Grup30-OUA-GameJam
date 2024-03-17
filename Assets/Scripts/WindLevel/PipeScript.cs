using UnityEngine;
using Random = UnityEngine.Random;

public class PipeScript : MonoBehaviour
{
    public float[] rotations = { 0, 90, 180, 270 };
    public float[] correctRotation;
    [SerializeField]
    bool isPlaced = false;
    int possibleRotations = 1;
    GameManager gameManager;

    // Döndürme toleransı
    float rotationTolerance = 0.1f;

    public AudioClip pipeRotateSound;
    private AudioSource audioSource;
    
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        audioSource = GetComponent<AudioSource>();
        
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        possibleRotations = correctRotation.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);
        CheckPlacement();
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));
        PlaySoundEffect();
        CheckPlacement();
    }
    
    private void PlaySoundEffect()
    {
        audioSource.volume = 0.2f;
       
        if (pipeRotateSound != null && audioSource != null)
        {
           
            audioSource.PlayOneShot(pipeRotateSound);
        }
    }

    private void CheckPlacement()
    {
        float rotatedAngle = transform.eulerAngles.z;
        bool isCorrectRotation = false;
        
        foreach (float expectedAngle in correctRotation)
        {
            if (Mathf.Abs(rotatedAngle - expectedAngle) < rotationTolerance)
            {
                isCorrectRotation = true;
                break;
            }
        }

        if (isCorrectRotation)
        {
            if (!isPlaced)
            {
                isPlaced = true;
                gameManager.CorrectMove();
            }
        }
        else
        {
            if (isPlaced)
            {
                isPlaced = false;
                gameManager.WrongMove();
            }
        }
    }
}
