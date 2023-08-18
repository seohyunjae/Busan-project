using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoogiButton_SY : MonoBehaviour
{
    [SerializeField] private string language = "";
    [SerializeField] private BoogiAction_SY boogiAction = null;
    [SerializeField] private SpeechBubbleText_SY speechBubbleText = null;

    public int textIndex = 0;

    public void SelectLanguageButton()
    {
        boogiAction.language = language;
    }

    public void ClickNextButton()
    {
        if (speechBubbleText.isTalking) return;
        boogiAction.isClickNextButton = true;
    }
}
