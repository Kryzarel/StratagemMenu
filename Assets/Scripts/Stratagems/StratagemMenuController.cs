using System.Collections.Generic;
using UnityEngine;

public class StratagemMenuController : MonoBehaviour
{
	[SerializeField] StratagemData[] selectedStratagems;

	public IReadOnlyList<StratagemData> SelectedStratagems => selectedStratagems;
}