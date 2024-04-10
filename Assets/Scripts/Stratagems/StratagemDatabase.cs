using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StratagemDatabase : ScriptableObject
{
	[SerializeField] StratagemData[] stratagems;

	public IReadOnlyList<StratagemData> Stratagems => stratagems;
}