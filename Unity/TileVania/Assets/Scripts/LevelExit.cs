using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float loadLevelDelay = 1f;

   void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextLevelCoroutine());
        }
   }

    IEnumerator LoadNextLevelCoroutine()
    { 
        yield return new WaitForSeconds(loadLevelDelay);
        int currentIndexScene = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentIndexScene + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) 
        { 
            nextSceneIndex = 0;
        }

        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
}
