using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class StratagemView : MonoBehaviour
{
	public HorizontalLayoutGroup horizontalLayout;
	public CanvasGroup CanvasGroup;
	public Image Image;
	public TextMeshProUGUI NameText;
	public TextMeshProUGUI BottomText;
	public Transform ArrowsParent;
	public Image ArrowPrefab;
	[ReadOnly]
	public List<Image> Arrows;
	[Space]
	public float[] ArrowRotations;

	public StratagemData StratagemData { get; private set; }

	public void SetUp(StratagemData stratagemData)
	{
		StratagemData = stratagemData;

		Image.sprite = stratagemData.Sprite;
		NameText.text = stratagemData.StratagemName;
		BottomText.gameObject.SetActive(false);
		ArrowsParent.gameObject.SetActive(true);
		SetUpArrows(stratagemData.Code);
	}

	private void OnValidate()
	{
		ArrowsParent.GetComponentsInChildren(Arrows);
	}

	private void Awake()
	{
		ArrowsParent.GetComponentsInChildren(Arrows);
	}

	private void SetUpArrows(IReadOnlyList<ArrowDirections> code)
	{
		PrefabList.SetUp(code, Arrows, ArrowPrefab, ArrowsParent, SetUp);

		void SetUp(int i, ArrowDirections direction, Image image)
		{
			image.rectTransform.localRotation = Quaternion.Euler(0, 0, ArrowRotations[(int)direction]);
		}
	}
}