using System.Collections;
using UnityEngine;

namespace Unity.VRTemplate
{
    /// <summary>
    /// Callout used to display information like world and controller tooltips.
    /// </summary>
    public class Callout : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The tooltip Transform associated with this Callout.")]
        Transform m_LazyTooltip;

        [SerializeField]
        [Tooltip("The line curve GameObject associated with this Callout.")]
        GameObject m_Curve;

        [SerializeField]
        [Tooltip("The required time to dwell on this callout before the tooltip and curve are enabled.")]
        float m_DwellTime = 1f;

        [SerializeField]
        [Tooltip("Whether the associated tooltip will be unparented on Start.")]
        bool m_Unparent = true;

        [SerializeField]
        [Tooltip("Whether the associated tooltip and curve will be disabled on Start.")]
        bool m_TurnOffAtStart = true;

        [SerializeField]
        [Tooltip("The fade duration for showing and hiding the tooltip and curve.")]
        float m_FadeDuration = 0.5f;

        bool m_Gazing = false;

        Coroutine m_StartCo;
        Coroutine m_EndCo;

        CanvasGroup m_TooltipCanvasGroup;
        CanvasGroup m_CurveCanvasGroup;

        void Start()
        {
            if (m_Unparent)
            {
                if (m_LazyTooltip != null)
                    m_LazyTooltip.SetParent(null);
            }

            if (m_LazyTooltip != null)
            {
                m_TooltipCanvasGroup = m_LazyTooltip.gameObject.GetComponent<CanvasGroup>();
                if (m_TooltipCanvasGroup == null)
                    m_TooltipCanvasGroup = m_LazyTooltip.gameObject.AddComponent<CanvasGroup>();
            }

            if (m_Curve != null)
            {
                m_CurveCanvasGroup = m_Curve.GetComponent<CanvasGroup>();
                if (m_CurveCanvasGroup == null)
                    m_CurveCanvasGroup = m_Curve.AddComponent<CanvasGroup>();
            }

            if (m_TurnOffAtStart)
            {
                if (m_TooltipCanvasGroup != null)
                    m_TooltipCanvasGroup.alpha = 0f;
                if (m_CurveCanvasGroup != null)
                    m_CurveCanvasGroup.alpha = 0f;
            }
        }

        public void GazeHoverStart()
        {
            m_Gazing = true;
            if (m_StartCo != null)
                StopCoroutine(m_StartCo);
            if (m_EndCo != null)
                StopCoroutine(m_EndCo);
            m_StartCo = StartCoroutine(StartDelay());
        }

        public void GazeHoverEnd()
        {
            m_Gazing = false;
            m_EndCo = StartCoroutine(EndDelay());
        }

        public void ShowCallout()
        {
            if (m_StartCo != null)
                StopCoroutine(m_StartCo);
            if (m_EndCo != null)
                StopCoroutine(m_EndCo);
            m_StartCo = StartCoroutine(StartDelay());
        }

        public void HideCallout()
        {
            if (m_StartCo != null)
                StopCoroutine(m_StartCo);
            if (m_EndCo != null)
                StopCoroutine(m_EndCo);
            m_EndCo = StartCoroutine(EndDelay());
        }

        IEnumerator StartDelay()
        {
            yield return FadeIn();
        }

        IEnumerator EndDelay()
        {
            yield return FadeOut();
        }

        IEnumerator FadeIn()
        {
            float elapsedTime = 0f;
            while (elapsedTime < m_FadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Clamp01(elapsedTime / m_FadeDuration);
                if (m_TooltipCanvasGroup != null)
                    m_TooltipCanvasGroup.alpha = alpha;
                if (m_CurveCanvasGroup != null)
                    m_CurveCanvasGroup.alpha = alpha;
                yield return null;
            }
        }

        IEnumerator FadeOut()
        {
            // Immediately return if the alpha values are already 0
            if (m_TooltipCanvasGroup != null && m_TooltipCanvasGroup.alpha == 0f)
            {
                yield break; // No need to fade out if already at 0 alpha
            }

            float elapsedTime = 0f;

            while (elapsedTime < m_FadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = 1f - Mathf.Clamp01(elapsedTime / m_FadeDuration);
                if (m_TooltipCanvasGroup != null)
                    m_TooltipCanvasGroup.alpha = alpha;
                if (m_CurveCanvasGroup != null)
                    m_CurveCanvasGroup.alpha = alpha;
                yield return null;
            }
        }
    }
}
