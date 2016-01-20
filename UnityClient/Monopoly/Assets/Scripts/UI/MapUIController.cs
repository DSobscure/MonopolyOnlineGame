using UnityEngine;
using UnityEngine.UI;
using MonopolyGame;

public class MapUIController : MonoBehaviour
{
    [SerializeField]
    private RectTransform blockPrefab;
    [SerializeField]
    private RectTransform mapPanel;
    [SerializeField]
    private MonopolyManager monopolyManager;

    private enum StreetPart
    {
        Left,
        Up,
        Right,
        Down
    }

    internal void UpdateMap(Map map)
    {
        for (int i = mapPanel.childCount - 1; i >= 0; i--)
        {
            Destroy(mapPanel.GetChild(i).gameObject);
        }
        RectTransform block;
        block = Instantiate(blockPrefab);
        block.transform.SetParent(mapPanel);
        block.localScale = Vector3.one;
        block.localPosition = new Vector3(-200f,-200f);
        block.GetComponent<RawImage>().color = new Color(0x63 / 255f,0x72 / 255f, 0xFA / 255f);
        block.GetChild(0).GetComponent<Text>().text = "Start";
        monopolyManager.blocks.Add(block);
        UpdateStreet(map, 1, 7, StreetPart.Left);

        block = Instantiate(blockPrefab);
        block.transform.SetParent(mapPanel);
        block.localScale = Vector3.one;
        block.localPosition = new Vector3(-200f, 200f);
        block.GetComponent<RawImage>().color = new Color(0xA4 / 255f, 0xA5 / 255f, 0xB0 / 255f);
        monopolyManager.blocks.Add(block);
        UpdateStreet(map, 9, 15, StreetPart.Up);

        block = Instantiate(blockPrefab);
        block.transform.SetParent(mapPanel);
        block.localScale = Vector3.one;
        block.localPosition = new Vector3(200f, 200f);
        block.GetComponent<RawImage>().color = new Color(0xA4 / 255f, 0xA5 / 255f, 0xB0 / 255f);
        monopolyManager.blocks.Add(block);
        UpdateStreet(map, 17, 23, StreetPart.Right);

        block = Instantiate(blockPrefab);
        block.transform.SetParent(mapPanel);
        block.localScale = Vector3.one;
        block.localPosition = new Vector3(200f, -200f);
        block.GetComponent<RawImage>().color = new Color(0xA4 / 255f, 0xA5 / 255f, 0xB0 / 255f);
        monopolyManager.blocks.Add(block);
        UpdateStreet(map, 25, 31, StreetPart.Down);
    }

    private void UpdateStreet(Map map, int startIndex, int emdIndex, StreetPart part)
    {
        RectTransform block;
        switch (part)
        {
            case StreetPart.Left:
                {
                    for (int i = 1,index = startIndex; index <= emdIndex; i++, index++)
                    {
                        block = Instantiate(blockPrefab);
                        block.transform.SetParent(mapPanel);
                        block.localScale = Vector3.one;
                        block.localPosition = new Vector3(-200, -200 + 50*i);
                        BlockDecoration(block, map.blocks[index]);
                        monopolyManager.blocks.Add(block);
                    }
                }
                break;
            case StreetPart.Up:
                {
                    for (int i = 1, index = startIndex; index <= emdIndex; i++, index++)
                    {
                        block = Instantiate(blockPrefab);
                        block.transform.SetParent(mapPanel);
                        block.localScale = Vector3.one;
                        block.localPosition = new Vector3(-200 + 50 * i, 200);
                        BlockDecoration(block, map.blocks[index]);
                        monopolyManager.blocks.Add(block);
                    }
                }
                break;
            case StreetPart.Right:
                {
                    for (int i = 1, index = startIndex; index <= emdIndex; i++, index++)
                    {
                        block = Instantiate(blockPrefab);
                        block.transform.SetParent(mapPanel);
                        block.localScale = Vector3.one;
                        block.localPosition = new Vector3(200 , 200 - 50 * i);
                        BlockDecoration(block, map.blocks[index]);
                        monopolyManager.blocks.Add(block);
                    }
                }
                break;
            case StreetPart.Down:
                {
                    for (int i = 1, index = startIndex; index <= emdIndex; i++, index++)
                    {
                        block = Instantiate(blockPrefab);
                        block.transform.SetParent(mapPanel);
                        block.localScale = Vector3.one;
                        block.localPosition = new Vector3(200 - 50 * i, -200);
                        BlockDecoration(block, map.blocks[index]);
                        monopolyManager.blocks.Add(block);
                    }
                }
                break;
        }
    }

    private void BlockDecoration(RectTransform blockPrefab, Block block)
    {
        Color color = new Color();
        string name = "";
        if (block is LandBlock)
        {
            color = new Color(0x00 / 255f, 0xB0 / 255f, 0x06 / 255f);
            name = (block as LandBlock).land.name;
        }
        else if (block is ChanceBlock)
        {
            color = new Color(0xFF / 255f, 0x28 / 255f, 0x28 / 255f);
            name = "Chance";
        }
        else if(block is DestinyBlock)
        {
            color = new Color(0xFF / 255f, 0xCC / 255f, 0x1F / 255f);
            name = "Destiny";
        }
        blockPrefab.GetComponent<RawImage>().color = color;
        blockPrefab.GetChild(0).GetComponent<Text>().text = name;
    }
}
