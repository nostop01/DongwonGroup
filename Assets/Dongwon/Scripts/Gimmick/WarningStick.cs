using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class WarningStick : PoolAble
{
    public MeshRenderer mesh; //����ȭ ������ ���� MeshRenderer
    public GameObject Spear; //��ȯ�� â ������Ʈ
    public GameObject Trans; //â ������Ʈ ��ȯ�� ��ġ��
    public GameObject Player; //�÷��̾� ������Ʈ

    // Start is called before the first frame update
    void OnEnable() //������Ʈ Ȱ��ȭ �Ǿ��� ��
    {
        mesh = GetComponent<MeshRenderer>(); //meshRenderer ������Ʈ ã��

        StartCoroutine(EMarkerGrid()); //�ڷ�ƾ ����

        //transform.position = Player.transform.position; //��� ������ ��ġ�� �÷��̾� ��ġ�� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator EMarkerGrid() //�ڷ�ƾ
    {
        int count = 0; //while�� �ݺ� ���ǿ� ��������

        while (count < 6) //count ���� 6 �̻��� �� while�� break
        {
            //�����ϰ� �ϴ� �ڵ�
            Color color1 = mesh.material.color; //�������� color1�� ã�Ƶ� MeshRenderer�� ���͸����� ���� ����
            color1.a = 0; //color1�� ���İ��� 0��
            mesh.material.color = color1; //MeshRenderer�� ���͸����� ���� color1���� ����.
            
            yield return new WaitForSeconds(0.15f); //0.15�� ��ٷ�.

            //�ٽ� ������ �ø��� �ڵ�
            Color color2 = mesh.material.color;
            color2.a = 0.8f;
            mesh.material.color = color2;

            yield return new WaitForSeconds(0.15f); //0.15�� ��ٷ�

            count++; //count�� ����.
        }

        yield return new WaitForSeconds(0.7f); //0.7�� ��ٷ�

        var SpearGo = ObjectPoolManager.instance.GetGo("Spear"); //������Ʈ Ǯ
        SpearGo.transform.position = Trans.transform.position; //â�� Ǯ���ϰ� �� ��ġ�� Trans������Ʈ�� Ʈ������ �����ǰ� ����

        ReleaseObject(); //������Ʈ ��ȯ
    }
}