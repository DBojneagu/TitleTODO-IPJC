using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterRacingMinigame : MonoBehaviour
{
    public string sceneToLoad;
    //public PlayerPositionHandler playerPositionHandler;
    public Transform playerTransform;
    public PlayerPositionHandler playerPositionHandler; // Reference to the PlayerPositionHandler script
    public Q44 taskCompletion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ferrari"))
        {
            // Save the player's position before transitioning to another scene
            //playerPositionHandler.SavePlayerPosition();
            //PlayerPrefs.SetFloat("PlayerX", playerTransform.position.x - 5);
            //PlayerPrefs.SetFloat("PlayerY", playerTransform.position.y - 5);
            //PlayerPrefs.SetFloat("PlayerZ", playerTransform.position.z);
            //PlayerPrefs.Save();
            //playerPositionHandler.SavePlayerPosition();
            PlayerCompletedTask();
            SceneManager.LoadScene(sceneToLoad);
        }

    }
    void PlayerCompletedTask()
    {
        int isCompletedRace = PlayerPrefs.GetInt("CompletedRace");
        if (taskCompletion != null && isCompletedRace == 0)
        {
            taskCompletion.isCompleted = true;
            PlayerPrefs.SetInt("CompletedRace", 1);
            PlayerPrefs.Save();

            //taskCompletion.CompleteTask();
        }
        else
        {
            Debug.LogError("TaskCompletion component not assigned.");
        }
        PlayerPrefs.SetInt("PointsRace", 0);
        PlayerPrefs.Save();
    }
}