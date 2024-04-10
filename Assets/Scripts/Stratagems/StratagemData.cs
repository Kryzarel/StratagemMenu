using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StratagemData : ScriptableObject
{
	[SerializeField] string stratagemName;
	[SerializeField] Sprite sprite;
	[SerializeField] ArrowDirections[] code;

	public string StratagemName => stratagemName;
	public Sprite Sprite => sprite;
	public IReadOnlyList<ArrowDirections> Code => code;
}