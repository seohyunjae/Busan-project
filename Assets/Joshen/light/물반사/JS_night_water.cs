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
        m_reflactionCamera = reflactionCameraGo.AddComponent<Camera>(); //카메라를 하나 생성해서 붙여 준다
        m_reflactionCamera.enabled = false;
        m_MainCamera = Camera.main;
        m_targetRenderTexture = new RenderTexture(Screen.width, Screen.height, 24);//24가 스텐실 버퍼임?
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

        Vector3 cameraDirectionWorldSpace = m_MainCamera.transform.forward;//메인카메라가 바라보는 방향
        Vector3 cameraUpWorldSpace = m_MainCamera.transform.up; //메인카메라 업 방향
        Vector3 cameraPositionWorldSpace = m_MainCamera.transform.position; //메인카메라의 월드상 위치 

        //트랜스폼 벡터를 마루상 위치로 변환

        Vector3 cameraDirectionPlaneSpace = m_reflectionPlane.transform.InverseTransformDirection(cameraDirectionWorldSpace);
        Vector3 cameraUpPlaneSpace = m_reflectionPlane.transform.InverseTransformDirection(cameraUpWorldSpace);
        Vector3 cameraPositionPlaneSpace = m_reflectionPlane.transform.InverseTransformPoint(cameraPositionWorldSpace);

        //벡터를 뒤집어 주기 
        cameraDirectionPlaneSpace.y *= -1.0f;
        cameraUpPlaneSpace.y *= -1.0f;
        cameraPositionPlaneSpace.y *= -1.0f;

        //뒤집어진 벡터를 다시 월드 스페이스로 변환

        cameraDirectionWorldSpace = m_reflectionPlane.transform.InverseTransformDirection(cameraDirectionPlaneSpace);
        cameraUpWorldSpace = m_reflectionPlane.transform.TransformDirection(cameraUpPlaneSpace);
        cameraPositionWorldSpace = m_reflectionPlane.transform.TransformPoint(cameraPositionPlaneSpace);

        //카메라 위치와 회전값 적용
        m_reflactionCamera.transform.position = cameraPositionWorldSpace;
        m_reflactionCamera.transform.LookAt(cameraPositionWorldSpace + cameraDirectionWorldSpace, cameraUpWorldSpace);

        //랜더타겟을 세팅해 준다
        m_reflactionCamera.targetTexture = m_targetRenderTexture;
        //랜더링
        m_reflactionCamera.Render();

        //아래 드로우를 호출
        DrawQuad();

    }


    void DrawQuad()
    {
        GL.PushMatrix();
        //미러 매터리얼을 적용해 주자
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