using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_night_water : MonoBehaviour
{
    Camera m_reflactionCamera;
    Camera m_MainCamera;

    public GameObject m_reflectionPlane;
    public Material MirrorMaterial;

    RenderTexture m_targetRenderTexture;
    // Start is called before the first frame update
    void Start()
    {
        GameObject reflactionCameraGo = new GameObject("ReflactionCamera");
        m_reflactionCamera = reflactionCameraGo.AddComponent<Camera>(); //ī�޶� �ϳ� �����ؼ� �ٿ� �ش�
        m_reflactionCamera.enabled = false;
        m_MainCamera = Camera.main;
        m_targetRenderTexture = new RenderTexture(Screen.width, Screen.height, 24);//24�� ���ٽ� ������?
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnPostRender()
    {
        RenderReflaction();
    }

    void RenderReflaction()
    {
        m_reflactionCamera.CopyFrom(m_MainCamera);

        Vector3 cameraDirectionWorldSpace = m_MainCamera.transform.forward;//����ī�޶� �ٶ󺸴� ����
        Vector3 cameraUpWorldSpace = m_MainCamera.transform.up; //����ī�޶� �� ����
        Vector3 cameraPositionWorldSpace = m_MainCamera.transform.position; //����ī�޶��� ����� ��ġ 

        //Ʈ������ ���͸� ����� ��ġ�� ��ȯ

        Vector3 cameraDirectionPlaneSpace = m_reflectionPlane.transform.InverseTransformDirection(cameraDirectionWorldSpace);
        Vector3 cameraUpPlaneSpace = m_reflectionPlane.transform.InverseTransformDirection(cameraUpWorldSpace);
        Vector3 cameraPositionPlaneSpace = m_reflectionPlane.transform.InverseTransformPoint(cameraPositionWorldSpace);

        //���͸� ������ �ֱ� 
        cameraDirectionPlaneSpace.y *= -1.0f;
        cameraUpPlaneSpace.y *= -1.0f;
        cameraPositionPlaneSpace.y *= -1.0f;

        //�������� ���͸� �ٽ� ���� �����̽��� ��ȯ

        cameraDirectionWorldSpace = m_reflectionPlane.transform.InverseTransformDirection(cameraDirectionPlaneSpace);
        cameraUpWorldSpace = m_reflectionPlane.transform.TransformDirection(cameraUpPlaneSpace);
        cameraPositionWorldSpace = m_reflectionPlane.transform.TransformPoint(cameraPositionPlaneSpace);

        //ī�޶� ��ġ�� ȸ���� ����
        m_reflactionCamera.transform.position = cameraPositionWorldSpace;
        m_reflactionCamera.transform.LookAt(cameraPositionWorldSpace + cameraDirectionWorldSpace, cameraUpWorldSpace);

        //����Ÿ���� ������ �ش�
        m_reflactionCamera.targetTexture = m_targetRenderTexture;
        //������
        m_reflactionCamera.Render();

        //�Ʒ� ��ο츦 ȣ��
        DrawQuad();

    }


    void DrawQuad()
    {
        GL.PushMatrix();
        //�̷� ���͸����� ������ ����
        MirrorMaterial.SetPass(0);
        MirrorMaterial.SetTexture("_ReflectionTex", m_targetRenderTexture);



        GL.LoadOrtho();
        GL.Begin(GL.QUADS);

        GL.TexCoord2(1.0f, 0.0f);
        GL.Vertex3(0.0f, 0.0f, 0.0f);

        GL.TexCoord2(1.0f, 1.0f);
        GL.Vertex3(0.0f, 1.0f, 0.0f);

        GL.TexCoord2(0.0f, 1.0f);
        GL.Vertex3(1.0f, 1.0f, 0.0f);

        GL.TexCoord2(0.0f, 0.0f);
        GL.Vertex3(1.0f, 0.0f, 0.0f);

        GL.End();
        GL.PopMatrix();
    }
}