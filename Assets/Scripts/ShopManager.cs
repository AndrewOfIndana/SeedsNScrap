using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private GameManager gManager;
    public TMP_Text moneyMenuUI;
    public CropCatalogue shoppingList;
    public GameObject purchasedItem;
    public Transform dropSite;
    private int shopID;

    void Awake()
    {        
        gManager = this.GetComponent<GameManager>();
        GameManagerUIMoneyUpdate();
    }

    public void GameManagerUIMoneyUpdate()
    {
        moneyMenuUI.text = "$ " + gManager.money.ToString();
    }

    void Purchase(int id)
    {
        Crop shoppingItemCrop = shoppingList.cropStatsCatalogue[id];
        float cost = shoppingItemCrop.seedValue;

        if ((gManager.money - cost) <= 0)
        {
            moneyMenuUI.color = new Color(255, 0, 0, 100);
            moneyMenuUI.text = "Insufficient Funds";
            StartCoroutine(GameManagerUIMoneyChangeBack());
        }
        else
        {
            gManager.SendMessage("LoseMoney", cost);
            GameManagerUIMoneyUpdate();
            GameObject droppedItemGameObject = (GameObject)Instantiate(purchasedItem, dropSite.position, dropSite.rotation);
            ItemController droppedItem = droppedItemGameObject.GetComponent<ItemController>();
            droppedItem.SetCrop(shoppingItemCrop);
        }
    }

    IEnumerator GameManagerUIMoneyChangeBack()
    {
        yield return new WaitForSecondsRealtime(1);
        moneyMenuUI.color = new Color(255, 221, 0, 255);
        moneyMenuUI.text = "$ " + gManager.money.ToString();
    }

    public void ShopItem01() { shopID = 0; Purchase(shopID);}
    public void ShopItem02() { shopID = 1; Purchase(shopID);}
    public void ShopItem03() { shopID = 2; Purchase(shopID);}
    public void ShopItem04() { shopID = 3; Purchase(shopID);}
    public void ShopItem05() { shopID = 4; Purchase(shopID);}
    public void ShopItem06() { shopID = 5; Purchase(shopID);}
    public void ShopItem07() { shopID = 6; Purchase(shopID);}
    public void ShopItem08() { shopID = 7; Purchase(shopID);}
    public void ShopItem09() { shopID = 8; Purchase(shopID);}
    public void ShopItem10() { shopID = 9; Purchase(shopID);}
    public void ShopItem11() { shopID = 10; Purchase(shopID);}
    public void ShopItem12() { shopID = 11; Purchase(shopID);}
    public void ShopItem13() { shopID = 12; Purchase(shopID);}
    public void ShopItem14() { shopID = 13; Purchase(shopID);}
    public void ShopItem15() { shopID = 14; Purchase(shopID);}
    public void ShopItem16() { shopID = 15; Purchase(shopID);}
    public void ShopItem17() { shopID = 16; Purchase(shopID);}
    public void ShopItem18() { shopID = 17; Purchase(shopID);}
    public void ShopItem19() { shopID = 18; Purchase(shopID);}
    public void ShopItem20() { shopID = 19; Purchase(shopID);}
    public void ShopItem21() { shopID = 20; Purchase(shopID);}
    public void ShopItem22() { shopID = 21; Purchase(shopID);}
    public void ShopItem23() { shopID = 22; Purchase(shopID);}
    public void ShopItem24() { shopID = 23; Purchase(shopID);}
    public void ShopItem25() { shopID = 24; Purchase(shopID);}
    public void ShopItem26() { shopID = 25; Purchase(shopID);}
    public void ShopItem27() { shopID = 26; Purchase(shopID);}
    public void ShopItem28() { shopID = 27; Purchase(shopID);}
    public void ShopItem29() { shopID = 28; Purchase(shopID);}
    public void ShopItem30() { shopID = 29; Purchase(shopID);}
    public void ShopItem31() { shopID = 30; Purchase(shopID);}
    public void ShopItem32() { shopID = 31; Purchase(shopID);}
    public void ShopItem33() { shopID = 32; Purchase(shopID);}
    public void ShopItem34() { shopID = 33; Purchase(shopID);}
    public void ShopItem35() { shopID = 34; Purchase(shopID);}
    public void ShopItem36() { shopID = 35; Purchase(shopID);}
    public void ShopItem37() { shopID = 36; Purchase(shopID);}
    public void ShopItem38() { shopID = 37; Purchase(shopID);}
    public void ShopItem39() { shopID = 38; Purchase(shopID);}
    public void ShopItem40() { shopID = 39; Purchase(shopID);}
    public void ShopItem41() { shopID = 40; Purchase(shopID);}
    public void ShopItem42() { shopID = 41; Purchase(shopID);}
    public void ShopItem43() { shopID = 42; Purchase(shopID);}
    public void ShopItem44() { shopID = 43; Purchase(shopID);}
    public void ShopItem45() { shopID = 44; Purchase(shopID);}
    public void ShopItem46() { shopID = 45; Purchase(shopID);}
    public void ShopItem47() { shopID = 46; Purchase(shopID);}
    public void ShopItem48() { shopID = 47; Purchase(shopID);}
    public void ShopItem49() { shopID = 48; Purchase(shopID);}
    public void ShopItem50() { shopID = 49; Purchase(shopID);}
    public void ShopItem51() { shopID = 50; Purchase(shopID);}
    public void ShopItem52() { shopID = 51; Purchase(shopID);}
    public void ShopItem53() { shopID = 52; Purchase(shopID);}
    public void ShopItem54() { shopID = 53; Purchase(shopID);}
    public void ShopItem55() { shopID = 54; Purchase(shopID);}
    public void ShopItem56() { shopID = 55; Purchase(shopID);}
    public void ShopItem57() { shopID = 56; Purchase(shopID);}
    public void ShopItem58() { shopID = 57; Purchase(shopID);}
    public void ShopItem59() { shopID = 58; Purchase(shopID);}
    public void ShopItem60() { shopID = 59; Purchase(shopID);}
    public void ShopItem61() { shopID = 60; Purchase(shopID);}
    public void ShopItem62() { shopID = 61; Purchase(shopID);}
    public void ShopItem63() { shopID = 62; Purchase(shopID);}
    public void ShopItem64() { shopID = 63; Purchase(shopID);}
    public void ShopItem65() { shopID = 64; Purchase(shopID);}
    public void ShopItem66() { shopID = 65; Purchase(shopID);}
    public void ShopItem67() { shopID = 66; Purchase(shopID);}
    public void ShopItem68() { shopID = 67; Purchase(shopID);}
    public void ShopItem69() { shopID = 68; Purchase(shopID);}
    public void ShopItem70() { shopID = 69; Purchase(shopID);}
    public void ShopItem71() { shopID = 70; Purchase(shopID);}
    public void ShopItem72() { shopID = 71; Purchase(shopID);}
    public void ShopItem73() { shopID = 72; Purchase(shopID);}
    public void ShopItem74() { shopID = 73; Purchase(shopID);}
    public void ShopItem75() { shopID = 74; Purchase(shopID);}
    public void ShopItem76() { shopID = 75; Purchase(shopID);}
    public void ShopItem77() { shopID = 76; Purchase(shopID);}
    public void ShopItem78() { shopID = 77; Purchase(shopID);}
    public void ShopItem79() { shopID = 78; Purchase(shopID);}
    public void ShopItem80() { shopID = 79; Purchase(shopID);}
    public void ShopItem81() { shopID = 80; Purchase(shopID);}
    public void ShopItem82() { shopID = 81; Purchase(shopID);}
    public void ShopItem83() { shopID = 82; Purchase(shopID);}
    public void ShopItem84() { shopID = 83; Purchase(shopID);}
    public void ShopItem85() { shopID = 84; Purchase(shopID);}
    public void ShopItem86() { shopID = 85; Purchase(shopID);}
    public void ShopItem87() { shopID = 86; Purchase(shopID);}
    public void ShopItem88() { shopID = 87; Purchase(shopID);}
    public void ShopItem89() { shopID = 88; Purchase(shopID);}
    public void ShopItem90() { shopID = 89; Purchase(shopID);}
    public void ShopItem91() { shopID = 90; Purchase(shopID);}
    public void ShopItem92() { shopID = 91; Purchase(shopID);}
    public void ShopItem93() { shopID = 92; Purchase(shopID);}
    public void ShopItem94() { shopID = 93; Purchase(shopID);}
    public void ShopItem95() { shopID = 94; Purchase(shopID);}
    public void ShopItem96() { shopID = 95; Purchase(shopID);}
    public void ShopItem97() { shopID = 96; Purchase(shopID);}
    public void ShopItem98() { shopID = 97; Purchase(shopID);}
    public void ShopItem99() { shopID = 98; Purchase(shopID);}
}
