using System.Collections;
using UnityEngine;

public class FinishGameButton : MonoBehaviour
{
    [SerializeField] private GameObject _circleAnimationPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var circleAnimation = Instantiate(_circleAnimationPrefab).GetComponent<CircleAnimator>();
        circleAnimation.IncreaseCircle();

        StartCoroutine(ExitGameCoroutine());
    }

    private IEnumerator ExitGameCoroutine()
    {
        yield return new WaitForSeconds(1f);
        QuitGame();
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
