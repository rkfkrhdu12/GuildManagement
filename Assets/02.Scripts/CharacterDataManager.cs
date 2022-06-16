using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataManager : MonoBehaviour
{
    GameManager _gameManager;
    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _gameManager.OnRegisterLoad();

        AddCharacterList("����ȣ�� ��Ű");
        AddCharacterList("������ ��Ű");
        AddCharacterList("���ڸ� ��Ű");
        AddCharacterList("��ũīī�� ��Ű");
        AddCharacterList("���� �ͻ�� ��Ű");
        AddCharacterList("�޺����� ��Ű");
        AddCharacterList("����ũ����� ��Ű");
        AddCharacterList("������� ��Ű");
        AddCharacterList("����� ��Ű");
        AddCharacterList("��ȭ�� ��Ű");
        AddCharacterList("�ٴٿ��� ��Ű");
        AddCharacterList("�����̾�� ��Ű");
        AddCharacterList("�Ҳ����� ��Ű");
        AddCharacterList("�������� ��Ű");
        AddCharacterList("�������� ��Ű");
        AddCharacterList("�ð����� ��Ű");
        AddCharacterList("�Ƿг���Ʈ ��Ű");
        AddCharacterList("�Ǹ��� ��Ű");
        AddCharacterList("��Ҹ��� ��Ű");
        AddCharacterList("��Ŭ����� ��Ű");
        AddCharacterList("���ݼ���� ��Ű");
        AddCharacterList("�����ڸ� ��Ű");
        AddCharacterList("�밨�� ��Ű");
        AddCharacterList("���� ��Ű");
        AddCharacterList("��������� ��Ű");
        AddCharacterList("������ ��Ű");
        AddCharacterList("����� ��Ű");
        AddCharacterList("õ�⳪�� ��Ű");
        AddCharacterList("õ��� ��Ű");
        AddCharacterList("ġ����� ��Ű");
        AddCharacterList("Ž�谡�� ��Ű");
        AddCharacterList("���Ϸ��� ��Ű");
        AddCharacterList("������ ��Ű");
        AddCharacterList("���� ��Ű");
        AddCharacterList("Ȧ������ ��Ű");
        AddCharacterList("����θ� ��Ű");

        _gameManager.OnLoadComplete();
    }

    void AddCharacterList(string line)
    {
        _gameManager.CharacterNameList.Add(line);
    }
}
