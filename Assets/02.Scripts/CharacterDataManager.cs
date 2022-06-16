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

        AddCharacterList("±¸¹ÌÈ£¸À ÄíÅ°");
        AddCharacterList("±ÙÀ°¸À ÄíÅ°");
        AddCharacterList("´ÑÀÚ¸À ÄíÅ°");
        AddCharacterList("´ÙÅ©Ä«Ä«¿À ÄíÅ°");
        AddCharacterList("´ÚÅÍ ¿Í»çºñ ÄíÅ°");
        AddCharacterList("´Şºû¼ú»ç ÄíÅ°");
        AddCharacterList("µş±âÅ©·¹Æä¸À ÄíÅ°");
        AddCharacterList("¸¶¹ı»ç¸À ÄíÅ°");
        AddCharacterList("¸í¶ûÇÑ ÄíÅ°");
        AddCharacterList("¸ñÈ­¸À ÄíÅ°");
        AddCharacterList("¹Ù´Ù¿äÁ¤ ÄíÅ°");
        AddCharacterList("¹ìÆÄÀÌ¾î¸À ÄíÅ°");
        AddCharacterList("ºÒ²ÉÁ¤·É ÄíÅ°");
        AddCharacterList("»şºª»ó¾î¸À ÄíÅ°");
        AddCharacterList("¼­¸®¿©¿Õ ÄíÅ°");
        AddCharacterList("½Ã°£Áö±â ÄíÅ°");
        AddCharacterList("½Ç·Ğ³ªÀÌÆ® ÄíÅ°");
        AddCharacterList("¾Ç¸¶¸À ÄíÅ°");
        AddCharacterList("¾îµÒ¸¶³à ÄíÅ°");
        AddCharacterList("¿¡Å¬·¹¾î¸À ÄíÅ°");
        AddCharacterList("¿¬±İ¼ú»ç¸À ÄíÅ°");
        AddCharacterList("¿¹¾ğÀÚ¸À ÄíÅ°");
        AddCharacterList("¿ë°¨ÇÑ ÄíÅ°");
        AddCharacterList("¿ë»ç¸À ÄíÅ°");
        AddCharacterList("¿ş¾î¿ïÇÁ¸À ÄíÅ°");
        AddCharacterList("Àü°¥¸À ÄíÅ°");
        AddCharacterList("Á»ºñ¸À ÄíÅ°");
        AddCharacterList("Ãµ³â³ª¹« ÄíÅ°");
        AddCharacterList("Ãµ»ç¸À ÄíÅ°");
        AddCharacterList("Ä¡¾î¸®´õ¸À ÄíÅ°");
        AddCharacterList("Å½Çè°¡¸À ÄíÅ°");
        AddCharacterList("ÆÄÀÏ·µ¸À ÄíÅ°");
        AddCharacterList("ÇØÀû¸À ÄíÅ°");
        AddCharacterList("Çãºê¸À ÄíÅ°");
        AddCharacterList("È¦¸®º£¸® ÄíÅ°");
        AddCharacterList("È÷¾î·Î¸À ÄíÅ°");

        _gameManager.OnLoadComplete();
    }

    void AddCharacterList(string line)
    {
        _gameManager.CharacterNameList.Add(line);
    }
}
