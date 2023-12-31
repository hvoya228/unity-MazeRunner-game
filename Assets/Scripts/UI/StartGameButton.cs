using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class StartGameButton : MonoBehaviour
{
    [SerializeField] private GameObject _circleAnimationPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("GreenScore", 0);
        PlayerPrefs.SetInt("PinkScore", 0);

        var circleAnimation = Instantiate(_circleAnimationPrefab).GetComponent<CircleAnimator>();
        circleAnimation.IncreaseCircle();

        StartCoroutine(LoadTimerSettingSceneCoroutine());
    }

    private IEnumerator LoadTimerSettingSceneCoroutine()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(LoadTimerSettingSceneCoroutineAsync());
    }

    private IEnumerator LoadTimerSettingSceneCoroutineAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("TimerSettingScene");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
