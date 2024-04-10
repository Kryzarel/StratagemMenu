using System.Collections.Generic;
using UnityEngine;
using Utils;

public class StratagemMenuView : MonoBehaviour
{
	[Header("Scene References")]
	[SerializeField] StratagemMenuController stratagemController;
	[SerializeField] StratagemView stratagemPrefab;
	[SerializeField] Transform stratagemParent;
	[SerializeField, ReadOnly] List<StratagemView> stratagemViews;

	private void Awake()
	{
		stratagemParent.GetComponentsInChildren(stratagemViews);

		PrefabList.SetUp(stratagemController.SelectedStratagems, stratagemViews, stratagemPrefab, stratagemParent, SetUp);

		static void SetUp(int i, StratagemData stratagemData, StratagemView view)
		{
			view.SetUp(stratagemData);
		}
	}
}