using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechBubbleText_SY : MonoBehaviour
{
    public List<string> npcTexts = null;
    public List<int> animeNums = null;
    public List<AudioClip> audioClip = null; 

    [SerializeField] private BoogiAction_SY boogiAction = null;
    public Animator boogiAni = null;
     public bool isTalking = false;

    public void SetNpcTalkAni(string _language, string _where)              // NPC ��ġ�� ���� ���� ��� �� �ִ� ����
    {
        if (npcTexts.Count > 0) npcTexts.Clear();
        if (animeNums.Count > 0) animeNums.Clear();
        if (audioClip.Count > 0) audioClip.Clear();

        if (_language == "KOR")
        {
            switch (_where)
            {
                case "StartPoint":
                    npcTexts.Add("�ȳ�?");
                    animeNums.Add(4);
                    audioClip.Add(Resources.Load<AudioClip>("StartPoint/StartPoint_1"));
                    npcTexts.Add("���� �α��� ��! �λ��� ������Ʈ��!");
                    animeNums.Add(2);
                    audioClip.Add(Resources.Load<AudioClip>("StartPoint/StartPoint_2"));
                    npcTexts.Add("�ʿ� �Բ� �����ϸ鼭 ���� ���ȸ��� ���� �Ұ����ٰž�.");
                    animeNums.Add(1);
                    audioClip.Add(Resources.Load<AudioClip>("StartPoint/StartPoint_3"));
                    npcTexts.Add("��ħ ��� ������ ���Ⱦ�.");
                    animeNums.Add(2);
                    audioClip.Add(Resources.Load<AudioClip>("StartPoint/StartPoint_4"));
                    npcTexts.Add("�������� ������ ���� ���� �μӹ�ȭ ������.");
                    animeNums.Add(1);
                    audioClip.Add(Resources.Load<AudioClip>("StartPoint/StartPoint_5"));
                    npcTexts.Add("��մ� �� �����״ϱ� ������ ���ƴٴϵ��� ��!");
                    animeNums.Add(3);
                    audioClip.Add(Resources.Load<AudioClip>("StartPoint/StartPoint_6"));
                    break;
                case "Worldexpo":
                    npcTexts.Add("���κ��尡 ���� ������?");
                    animeNums.Add(3);
                    audioClip.Add(Resources.Load<AudioClip>("Worldexpo/Worldexpo_1"));
                    npcTexts.Add("2030�⿡ �λ꿡�� ���忢������ ���� �� �ֵ��� ����ϴ� �������̾�!");
                    animeNums.Add(1);
                    audioClip.Add(Resources.Load<AudioClip>("Worldexpo/Worldexpo_2"));
                    npcTexts.Add("���ֵȴٸ� ����ڶ�ȸ�� �ø���, ������, �� �� ������ �ް� �̺�Ʈ�� ��� �����ϴ� 7��° ������ �� �� �ִ�!");
                    animeNums.Add(2);
                    audioClip.Add(Resources.Load<AudioClip>("Worldexpo/Worldexpo_3"));
                    npcTexts.Add("�Ӹ� �ƴ϶� ������ �����ϴ� ��Ⱑ �� �� �ִٰ� �����.");
                    animeNums.Add(1);
                    audioClip.Add(Resources.Load<AudioClip>("Worldexpo/Worldexpo_4"));
                    npcTexts.Add("�ް� ����� ������ �̷� ������ ���밡 �λ��� �ȴٸ� ���� ���� �� ����!");
                    animeNums.Add(3);
                    audioClip.Add(Resources.Load<AudioClip>("Worldexpo/Worldexpo_5"));
                    break;
                case "SnailTalk":
                    npcTexts.Add("���ζ� ���� ���� ������?");
                    animeNums.Add(3);
                    audioClip.Add(Resources.Load<AudioClip>("SnailTalk/SnailTalk_1"));
                    npcTexts.Add("�̰� Ư���� ��ü��, ������ ���̾�!");
                    animeNums.Add(2);
                    audioClip.Add(Resources.Load<AudioClip>("SnailTalk/SnailTalk_2"));
                    npcTexts.Add("������ ������ǰ���μ� ��Ư�� �����⸦ ������ �� �ƴ϶� �̰��� ������ ������ 1��ڿ� �߼۵� ����.");
                    animeNums.Add(1);
                    audioClip.Add(Resources.Load<AudioClip>("SnailTalk/SnailTalk_3"));
                    npcTexts.Add("1�� ���� �ʿ��� ���� ���� �ִٸ� �����غ�!");
                    animeNums.Add(3);
                    audioClip.Add(Resources.Load<AudioClip>("SnailTalk/SnailTalk_4"));
                    break;
                case "HelloGAL":
                    npcTexts.Add("���ȸ��� ���� ���縦 ���ϰ� �־�!");
                    animeNums.Add(2);
                    audioClip.Add(Resources.Load<AudioClip>("HelloGAL/HelloGAL_1"));
                    npcTexts.Add("����ô���� ���ȸ� �ϴ�� ���̸����̾��µ� 1960������ �������� �����ϱ� �����߾�.");
                    animeNums.Add(3);
                    audioClip.Add(Resources.Load<AudioClip>("HelloGAL/HelloGAL_2"));
                    npcTexts.Add("�̶����� �ؼ������ �ްԽü��� �����ư�, �����ֹε�� �������鿡�� �α��ִ� �޾����� �Ǿ���.");
                    animeNums.Add(1);
                    audioClip.Add(Resources.Load<AudioClip>("HelloGAL/HelloGAL_3"));
                    npcTexts.Add("1970��� �Ĺݿ��� ���ȴ뱳�� �Ǽ��ư� ���ȸ��� ��¡�� �Ǿ���.");
                    animeNums.Add(3);
                    audioClip.Add(Resources.Load<AudioClip>("HelloGAL/HelloGAL_4"));
                    npcTexts.Add("1980��� ���Ŀ� ��������� ����ȭ�� ������ �޾� ȣ��, ����Ʈ, ����ü� ���� �Ǽ��ư�");
                    animeNums.Add(1);
                    audioClip.Add(Resources.Load<AudioClip>("HelloGAL/HelloGAL_5"));
                    npcTexts.Add("�غ������� �پ��� �������, ī��, �������� �����Ǿ� ������ ���ȸ��� �Ǿ���.");
                    animeNums.Add(3);
                    audioClip.Add(Resources.Load<AudioClip>("HelloGAL/HelloGAL_6"));
                    npcTexts.Add("���� ����� �Բ� �޾��� ���Ե� �ŷ����� �����̶� �λ���� ��ǥ���� ���� ��ҷ� �˷�����.");
                    animeNums.Add(1);
                    audioClip.Add(Resources.Load<AudioClip>("HelloGAL/HelloGAL_7"));
                    break;
                case "Eobangnori":
                    npcTexts.Add("���~! ������� ��� ���̸� �ϰ� �־�!");
                    animeNums.Add(3);
                    audioClip.Add(Resources.Load<AudioClip>("Eobangnori/Eobangnori_1"));
                    npcTexts.Add("�����̴� ���� ������������ ���µǴ� �����ε� ��� �۾������� �뵿�並 ����ȭ �Ѱž�");
                    animeNums.Add(2);
                    audioClip.Add(Resources.Load<AudioClip>("Eobangnori/Eobangnori_2"));
                    npcTexts.Add("���ظ� �����ؼ� �ٴٿ� ������ ���� �°� ���̸� �ϸ鼭 �������� ���ƿ��⸦ ����ϴ� ���̿���");
                    animeNums.Add(1);
                    audioClip.Add(Resources.Load<AudioClip>("Eobangnori/Eobangnori_3"));
                    npcTexts.Add("�츮���� ������ ��������ⱸ, �¼����� ��� ������̶�� ������ ū �ǹ̸� ������ ������ȭ���");
                    animeNums.Add(2);
                    audioClip.Add(Resources.Load<AudioClip>("Eobangnori/Eobangnori_4"));
                    break;
                case "EobangFestival":
                    npcTexts.Add("���ȸ������� �ų� ��� ������ ��.");
                    animeNums.Add(3);
                    audioClip.Add(Resources.Load<AudioClip>("EobangFestival/EobangFestival_1"));
                    npcTexts.Add("�ѱ����� ���Ϲ����� ��������� �μӹ�ȭ�� ����� �� ������.");
                    animeNums.Add(2);
                    audioClip.Add(Resources.Load<AudioClip>("EobangFestival/EobangFestival_2"));
                    npcTexts.Add("�����ô� ������ ����� ��� �����۾�ü�� ����桯�� ����� �ϰ��־ ������ ���� �������� ���̴� ���������� �ñ״�ó �̺�Ʈ��.");
                    animeNums.Add(1);
                    audioClip.Add(Resources.Load<AudioClip>("EobangFestival/EobangFestival_3"));
                    npcTexts.Add("20����� 4�� ���� ��ȭ���������� ������ ������ ���뼺�� �����޾Ҿ�.");
                    animeNums.Add(2);
                    audioClip.Add(Resources.Load<AudioClip>("EobangFestival/EobangFestival_4"));
                    npcTexts.Add("���ó� ü�� ���α׷����� �پ��ϰ� ��� �� �����ϱ� ����ġ�� ���� �� ��������� ��!");
                    animeNums.Add(3);
                    audioClip.Add(Resources.Load<AudioClip>("EobangFestival/EobangFestival_5"));
                    break;
                case "WishLightStreet":
                    npcTexts.Add("���� �Ҹ��� �׸��Ÿ���!");
                    animeNums.Add(3);
                    audioClip.Add(Resources.Load<AudioClip>("WishLightStreet/WishLightStreet_1"));
                    npcTexts.Add("����������� ���� ������ �� ���� ���Ÿ� �� �ϳ���!");
                    animeNums.Add(1);
                    audioClip.Add(Resources.Load<AudioClip>("WishLightStreet/WishLightStreet_2"));
                    npcTexts.Add("�����ֹε��� �� �� �Ҹ��� ������ ��� ����ϰ� ������ ���������� �����ϱ� ���� ��������!");
                    animeNums.Add(2);
                    audioClip.Add(Resources.Load<AudioClip>("WishLightStreet/WishLightStreet_3"));
                    npcTexts.Add("�̰����� �Ƹ��ٿ� �߰��� �Բ� ��ܺ��� �� �?");
                    animeNums.Add(3);
                    audioClip.Add(Resources.Load<AudioClip>("WishLightStreet/WishLightStreet_4"));
                    break;
            }
        }

        if (_language == "ENG")
        {
            switch (_where)
            {
                case "StartPoint":
                    npcTexts.Add("Hi!");
                    animeNums.Add(4);
                    npcTexts.Add("My name is Boogi! Maskot paper in Busan!");
                    animeNums.Add(2);
                    npcTexts.Add("While traveling with you, I will introduce Gwangalli here.");
                    animeNums.Add(1);
                    npcTexts.Add("It's just in time for the Eobang Festival.");
                    animeNums.Add(2);
                    npcTexts.Add("It is the only traditional fishing village folk culture festival in the country.");
                    animeNums.Add(1);
                    npcTexts.Add("There will be a lot of fun, so go around as much as you want!");
                    animeNums.Add(3);
                    break;
                case "Worldexpo":
                    npcTexts.Add("Isn't the surfboard cool?");
                    animeNums.Add(3);
                    npcTexts.Add("It is a sculpture that wishes for the World Expo to be held in Busan in 2030!");
                    animeNums.Add(1);
                    npcTexts.Add("If held, it could be the seventh country to host all three mega events: the World Expo, the Olympics, and the World Cup!");
                    animeNums.Add(2);
                    npcTexts.Add("Not only that, but I heard that it can be an opportunity for the country to take off.");
                    animeNums.Add(1);
                    npcTexts.Add("It would be great if the stage of future generations that will realize their dreams and hopes becomes Busan!");
                    animeNums.Add(3);
                    break;
                case "SnailTalk":
                    npcTexts.Add("Isn't the aurora light really pretty?");
                    animeNums.Add(3);
                    npcTexts.Add("This is a special mailbox, 'snail talk'!");
                    animeNums.Add(2);
                    npcTexts.Add("Not only does it create a unique atmosphere as a kind of artwork, but if you put a postcard here, please send it a year later!");
                    animeNums.Add(1);
                    npcTexts.Add("If you have anything to say to you in a year's time, join us!");
                    animeNums.Add(3);
                    break;
                case "HelloGAL":
                    npcTexts.Add("Gwangalli has a long history.");
                    animeNums.Add(2);
                    npcTexts.Add("Since the Goryeo Dynasty, Gwangalli has been a fishing village, and it has developed into a tourist destination since the 1960s.");
                    animeNums.Add(3);
                    npcTexts.Add("Since then, beaches and rest facilities have been established, and it has become a popular resort for local residents and tourists.");
                    animeNums.Add(1);
                    npcTexts.Add("Gwangandaegyo Bridge was built in the late 1970s and became a symbol of Gwangalli.");
                    animeNums.Add(3);
                    npcTexts.Add("Since the 1980s, hotels, resorts, and commercial facilities have been built under the influence of the tourism industry");
                    animeNums.Add(1);
                    npcTexts.Add("and urbanization, and various restaurants, cafes, and shops have been formed on the beach, making it the current Gwangalli.");
                    animeNums.Add(3);
                    npcTexts.Add(" It is known as a representative tourist attraction in Busan because it is an attractive area with a long history and defective recreation.");
                    animeNums.Add(1);
                    break;
                case "Eobangnori":
                    npcTexts.Add("Wow! People are playing Eobang!");
                    animeNums.Add(3);
                    npcTexts.Add("Eobang Nori is a game that is handed down here in Suyeong area, and it is a play of fishing process and labor songs.");
                    animeNums.Add(2);
                    npcTexts.Add("Before going to the sea for the new year, it was a game to play with the gut and pray for a return to Manseon.");
                    animeNums.Add(1);
                    npcTexts.Add(" It is an intangible cultural property with great significance in that it is the only fishing cooperative organization in Korea, the Eobang traditional game of Jwasuyeong.");
                    animeNums.Add(2);
                    break;
                case "EobangFestival":
                    npcTexts.Add("There is an Eobang Festival every year in Gwangalli. ");
                    animeNums.Add(3);
                    npcTexts.Add("It is a festival based on the folk culture of traditional fishing villages, which is unique in Korea.");
                    animeNums.Add(2);
                    npcTexts.Add("It is a signature event unique to Suyeong-gu, where many domestic and foreign visitors gather, as it is based on Eobang, a fishing joint work between naval forces and fishermen in the Joseon Dynasty.");
                    animeNums.Add(1);
                    npcTexts.Add("It has been recognized for its legitimacy to the extent that it has been selected as a cultural tourism festival for four consecutive years since 2020.");
                    animeNums.Add(2);
                    npcTexts.Add("You can enjoy various exhibitions and experience programs, so don't miss it and make sure to stop by!");
                    animeNums.Add(3);
                    break;
                case "WishLightStreet":
                    npcTexts.Add("This is a wish light theme street!");
                    animeNums.Add(3);
                    npcTexts.Add("It's one of the must-see attractions at the Eobang Festival!");
                    animeNums.Add(1);
                    npcTexts.Add("It was built to gather the wishes and wishes of local residents for the year and to successfully hold the festival!");
                    animeNums.Add(2);
                    npcTexts.Add("How about enjoying the beautiful night view together here?");
                    animeNums.Add(3);
                    break;
            }
        }
    }

    public void PlayTyping(int num)
    {
        if (num <= npcTexts.Count - 1)
        {
            if (boogiAction.SpeechBubble.activeSelf) StartCoroutine(Typing(npcTexts[num]));
        }
        else if (num > npcTexts.Count - 1)
        {
            boogiAction.isClickNextButton = false;
            boogiAction.SpeechBubble.SetActive(false);
            boogiAni.SetInteger("AniNum", 0);
        }
    }

    IEnumerator Typing(string text)
    {
        isTalking = true;
        boogiAction.isClickNextButton = false;

        string addText = "";

        foreach (char letter in text.ToCharArray())
        {
            addText = addText + letter;
            transform.gameObject.GetComponent<TextMeshProUGUI>().text = addText;

            yield return new WaitForSeconds(0.2f);
        }
        isTalking = false;
    }

    public void PlayAnim(int num) 
    {
        if (num >= animeNums.Count) return;
        boogiAni.SetInteger("AniNum", animeNums[num]);
    }

    public void PlayVoice(int num)
    {
        if (num >= audioClip.Count) return;
        if (GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Pause();

        GetComponent<AudioSource>().clip = audioClip[num];
        GetComponent<AudioSource>().volume = 0.5f; // ����!!!!!!!!!!!!!!!!!
        GetComponent<AudioSource>().Play();
    }
}
