using UnityEngine;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    // A Level holds the camera and ball spawn point for one level
    [System.Serializable]
    public class Level
    {
        public Camera camera;
        public Transform ballSpawnPoint;
    }

    // Fill these in the Inspector
    public Level[] levels;           // All your levels
    public BallController ball;      // The ball in the scene
    public TextMeshProUGUI winText;  // The "You Win" UI text
    public float nextLevelDelay = 2f; // Seconds to wait before loading the next level

    private int currentLevel = 0;                  // Tracks which level we're on
    public int CurrentLevel => currentLevel;        // Lets other scripts read currentLevel (but not change it)

    void Start()
    {
        LoadLevel(0); // Always start on the first level
    }

    void Update()
    {
        // Nothing runs every frame — this is just a placeholder
    }

    // Called by another script (e.g. BallController) when the ball reaches the goal
    public void OnBallWin()
    {
        winText.gameObject.SetActive(true);                  // Show the win message
        Invoke(nameof(GoToNextLevel), nextLevelDelay);       // Wait, then go to the next level
    }

    // Moves to the next level, or ends the game if all levels are done
    void GoToNextLevel()
    {
        int next = currentLevel + 1;

        if (next >= levels.Length) // No more levels left
        {
            winText.text = "You Win! All levels completed!";
            winText.gameObject.SetActive(true);
            return; // Stop here — game is complete
        }

        winText.gameObject.SetActive(false); // Hide the win message
        LoadLevel(next);
    }

    // Sets up a level by index: activates its camera and repositions the ball
    public void LoadLevel(int index)
    {
        currentLevel = index;

        // Loop through every level and only activate the camera for the current one
        for (int i = 0; i < levels.Length; i++)
            levels[i].camera.gameObject.SetActive(i == index);

        // Move the ball to this level's spawn point
        Level lvl = levels[index];
        ball.transform.position = lvl.ballSpawnPoint.position;

        // Stop the ball from carrying over any movement from the previous level
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}