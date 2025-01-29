using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1f;
    private Canvas fadeCanvas;
    private Image fadeImage;
    private static SceneChanger instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            CreateFadeCanvas();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreateFadeCanvas()
    {
        if (fadeCanvas == null)
        {
            GameObject canvasObj = new GameObject("FadeCanvas");
            fadeCanvas = canvasObj.AddComponent<Canvas>();
            fadeCanvas.renderMode = RenderMode.ScreenSpaceCamera;
            fadeCanvas.worldCamera = Camera.main;
            fadeCanvas.planeDistance = 0.001f;
            DontDestroyOnLoad(fadeCanvas.gameObject);
            
            fadeImage = new GameObject("FadeImage").AddComponent<Image>();
            fadeImage.transform.SetParent(fadeCanvas.transform, false);
            fadeImage.rectTransform.anchorMin = Vector2.zero;
            fadeImage.rectTransform.anchorMax = Vector2.one;
            fadeImage.rectTransform.sizeDelta = Vector2.zero;
            fadeImage.color = new Color(1f, 1f, 1f, 0f); // Transparent au départ
        }
    }

    public void ChangeScene()
    {
        StartCoroutine(FadeAndSwitchScene());
    }

    private IEnumerator FadeAndSwitchScene()
    {
        yield return StartCoroutine(Fade(0f, 1f));

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            fadeImage.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        fadeImage.color = new Color(1f, 1f, 1f, endAlpha);
    }
}