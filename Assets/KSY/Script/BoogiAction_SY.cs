using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoogiAction_SY : MonoBehaviour
{
    [SerializeField] private SpeechBubbleText_SY speechText = null;
    [SerializeField] private GameObject languageSelectButton = null;
    [SerializeField] private GameObject nextButton = null;
    public GameObject SpeechBubble = null;
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject HelloParticle = null;
    [SerializeField] private GameObject ByeParticle = null;
    [SerializeField] private GameObject spawnPosint = null;

    [SerializeField] private ParticleSystem Hello = null;
    [SerializeField] private ParticleSystem Bye = null;

    [SerializeField] private AudioSource audioSource = null;

    private bool boogiIn = false;
    
    public string language = "";
    private bool isPickLanguage = false;
    public int textIndex = 0;
    public bool isClickNextButton = false;

    

    private void Awake()
    {
        ByeParticle.SetActive(false);           // ��ƼŬ Pause�� Awake������ �ǹ̰� ������...;; 
        transform.GetChild(0).gameObject.SetActive(false); // �α� ����
        if (!player) player = GameObject.FindWithTag("Player"); // �÷��̾� �ڵ� ����
        if (!spawnPosint) Debug.LogError("spawnPosint���������������~!!!"); // �α� ���� ��ġ ����
        SetBoogiPosition();                     // �α� ������ġ�� �̵�
        if (!audioSource) audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (!HelloParticle.activeSelf) HelloParticle.SetActive(true); // Hello ����Ʈ ����
        audioSource.clip = Resources.Load<AudioClip>("AudioSource/HelloBoogiSound");
        audioSource.Play();
        StartCoroutine(BoogiStart());
    }
    private IEnumerator BoogiStart()
    {
        yield return new WaitForSeconds(0.3f);

        transform.GetChild(0).gameObject.SetActive(true);       // ��ü��� ����
        if (nextButton.activeSelf) nextButton.SetActive(false); // ���� ��ư ������
        if (!SpeechBubble.activeSelf) SpeechBubble.SetActive(true);  // ��ǳ�� �ѱ�
        speechText.gameObject.GetComponent<TextMeshProUGUI>().text = "�� �����ϼ���.\n(Choose a Language)";     // �ؽ�Ʈ ����
    }


    private void Update()
    {
        LookPlayer();       // �÷��̾� ����

        if (!isPickLanguage && (language == "KOR" || language == "ENG"))
        { 
            if (languageSelectButton.activeSelf) languageSelectButton.SetActive(false);     // ��� ���� ��ư ��Ȱ��ȭ
            if (SpeechBubble.activeSelf) SpeechBubble.SetActive(false);                     // ��ǳ�� ��Ȱ��ȭ
            if (!ByeParticle.activeSelf) ByeParticle.SetActive(true);                       // Bye ��ƼŬ Ȱ��ȭ
            audioSource.clip = Resources.Load<AudioClip>("AudioSource/ByeBoogiSound");
            audioSource.Play();
            if (transform.GetChild(0).gameObject.activeSelf) transform.GetChild(0).gameObject.SetActive(false); // �α� ��Ȱ��ȭ
            isPickLanguage = true;      // ��� ���� �Ϸ�
        }
    }
    private void LookPlayer()
    {
        Vector3 dir = transform.position - player.transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 3f);
    }

    public void PlayerOnTriggerEnter(Collider other)
    {
        if (!isPickLanguage) return;

        if (other.gameObject.tag == "TouristAttraction")        // ������ �������� ��Ҵٸ�
        {
            StartCoroutine(MomentToEnter(other));
        }
    }

    private IEnumerator MomentToEnter(Collider other)
    {
        boogiIn = true;

        if (!transform.GetChild(0).gameObject.activeSelf)
        {
            Hello.Play();
            audioSource.clip = Resources.Load<AudioClip>("AudioSource/HelloBoogiSound");
            audioSource.Play();

            yield return new WaitForSeconds(0.25f);

            transform.GetChild(0).gameObject.SetActive(true);
            SetBoogiPosition();
        } 
        if (!SpeechBubble.activeSelf) SpeechBubble.SetActive(true);
        speechText.gameObject.GetComponent<TextMeshProUGUI>().text = "";
        if (!nextButton.activeSelf) nextButton.SetActive(true);
        if (textIndex != 0) textIndex = 0;
        speechText.SetNpcTalkAni(language, other.gameObject.name);          // ���+�ִ�+�Ҹ�
    }

    public void PlayerOnTriggerStay(Collider other)
    {
        if (!isPickLanguage) return;

        if (other.gameObject.tag == "TouristAttraction")
        {
            if (language == "KOR")
            {
                if (!isClickNextButton && textIndex == 0)
                {
                    speechText.PlayTyping(textIndex);
                    speechText.PlayAnim(textIndex);
                    speechText.PlayVoice(textIndex);
                    textIndex++;
                } 
                else if(isClickNextButton)
                {
                    isClickNextButton = false;
                    speechText.PlayTyping(textIndex);
                    speechText.PlayAnim(textIndex);
                    speechText.PlayVoice(textIndex);
                    textIndex++;
                }

            }

            else if(language == "ENG")
            {
                if (!isClickNextButton && textIndex == 0)
                {
                    speechText.PlayTyping(textIndex);
                    speechText.PlayAnim(textIndex);
                    textIndex++;
                }
                else if (isClickNextButton)
                {
                    isClickNextButton = false;
                    speechText.PlayTyping(textIndex);
                    speechText.PlayAnim(textIndex);

                    textIndex++;
                }
            }
           
        }
    }

    public void PlayerOnTriggerExit(Collider other)
    {
        if (!isPickLanguage) return;

        if (other.gameObject.tag == "TouristAttraction")
        {
            boogiIn = false;
            StartCoroutine(MomentToExit());
            // SpeechBubble.GetComponent<AudioSource>().Pause();   
        }
    }

    private IEnumerator MomentToExit()
    {
        if (SpeechBubble.activeSelf) SpeechBubble.SetActive(false);
        if (textIndex != 0) textIndex = 0;

        yield return new WaitForSeconds(2.0f);

        if (!boogiIn)
        { 
            transform.GetChild(0).gameObject.SetActive(false);
            audioSource.clip = Resources.Load<AudioClip>("AudioSource/ByeBoogiSound");
            audioSource.Play();

            yield return new WaitForSeconds(0.1f);

            if (!ByeParticle.activeSelf) ByeParticle.SetActive(true);
            Bye.Play();
        }

    }

    private void SetBoogiPosition()
    {
        transform.position = spawnPosint.transform.position;
        transform.rotation = spawnPosint.transform.rotation;
    }
}
