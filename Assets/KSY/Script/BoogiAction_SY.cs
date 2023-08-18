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
        ByeParticle.SetActive(false);           // 파티클 Pause가 Awake에서는 의미가 없나봄...;; 
        transform.GetChild(0).gameObject.SetActive(false); // 부기 끄기
        if (!player) player = GameObject.FindWithTag("Player"); // 플레이어 자동 설정
        if (!spawnPosint) Debug.LogError("spawnPosint넣으세요오오오오~!!!"); // 부기 생성 위치 설정
        SetBoogiPosition();                     // 부기 생성위치로 이동
        if (!audioSource) audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (!HelloParticle.activeSelf) HelloParticle.SetActive(true); // Hello 이펙트 시행
        audioSource.clip = Resources.Load<AudioClip>("AudioSource/HelloBoogiSound");
        audioSource.Play();
        StartCoroutine(BoogiStart());
    }
    private IEnumerator BoogiStart()
    {
        yield return new WaitForSeconds(0.3f);

        transform.GetChild(0).gameObject.SetActive(true);       // 전체모습 들어내기
        if (nextButton.activeSelf) nextButton.SetActive(false); // 다음 버튼 가리기
        if (!SpeechBubble.activeSelf) SpeechBubble.SetActive(true);  // 말풍선 켜기
        speechText.gameObject.GetComponent<TextMeshProUGUI>().text = "언어를 선택하세요.\n(Choose a Language)";     // 텍스트 설정
    }


    private void Update()
    {
        LookPlayer();       // 플레이어 보기

        if (!isPickLanguage && (language == "KOR" || language == "ENG"))
        { 
            if (languageSelectButton.activeSelf) languageSelectButton.SetActive(false);     // 언어 선택 버튼 비활성화
            if (SpeechBubble.activeSelf) SpeechBubble.SetActive(false);                     // 말풍선 비활성화
            if (!ByeParticle.activeSelf) ByeParticle.SetActive(true);                       // Bye 파티클 활성화
            audioSource.clip = Resources.Load<AudioClip>("AudioSource/ByeBoogiSound");
            audioSource.Play();
            if (transform.GetChild(0).gameObject.activeSelf) transform.GetChild(0).gameObject.SetActive(false); // 부기 비활성화
            isPickLanguage = true;      // 언어 설정 완료
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

        if (other.gameObject.tag == "TouristAttraction")        // 설정된 관광지와 닿았다면
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
        speechText.SetNpcTalkAni(language, other.gameObject.name);          // 대사+애니+소리
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
