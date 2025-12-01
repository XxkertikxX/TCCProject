using UnityEngine;
using UnityEngine.UI;

public class ShowCharactersInfo : MonoBehaviour
{
    [SerializeField] private Text[] textosInfo;
    [SerializeField] private Text[] textosAtaques;
    [SerializeField] private StatusCharacters actualStatus;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite nonCharacterBackGround;
    private int nameFontSize;
    public void ShowStatusInfo(StatusCharacters status)
    {
        actualStatus = status;
        textosInfo[0].fontSize = nameFontSize;
        textosInfo[0].text = status.Name;
        textosInfo[1].text = status.Level.ToString();
        textosInfo[2].text = status.Life.ToString();
        textosInfo[3].text = status.Defense.ToString();
        textosInfo[4].text = status.Power.ToString();
    }

    public void ShowElementType(string type)
    {
        textosInfo[5].text = type;
    }

    public void ShowMana(ManaSO mana)
    {
        textosInfo[6].text = mana.Mana.ToString();
    }

    public void ShowAttackInfo(AttackDesck attackInfo)
    {
        textosAtaques[0].text = attackInfo.DescAttac1 + " " + actualStatus.Skills[0].ManaConsume;
        textosAtaques[1].text = attackInfo.DescAttac2 + " " + actualStatus.Skills[1].ManaConsume;
    }

    public void ShowPersonalBackGround(Sprite background)
    {
        backgroundImage.sprite = background;
    }


    private void OnEnable()
    {
        actualStatus = null;
        backgroundImage.sprite = nonCharacterBackGround;
        for(int i = 0; i < textosInfo.Length; i++)
        {
            if(i != 0)
            {
                textosInfo[i].text = "-----";
            }
            else
            {
                nameFontSize = textosInfo[0].fontSize;
                textosInfo[0].fontSize = 23;
                textosInfo[0].text = "Selecione um personagem";
            }
        }
        textosAtaques[0].text = "------------------------------------------------------------------------------------------------------------";
        textosAtaques[1].text = "------------------------------------------------------------------------------------------------------------------------------------------------------------------";
    }
}
