using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Object;

namespace Utils
{
	public class PrefabList
	{
		public static void SetUp<T1, T2>(IReadOnlyList<T1> data, List<T2> monoBehaviours, T2 prefab, Transform parent, Action<int, T1, T2> setUp, Action<int, T1, T2> onInstantiate = null) where T2 : MonoBehaviour
		{
			monoBehaviours.Capacity = Math.Max(monoBehaviours.Capacity, data.Count);

			for (int i = 0; i < data.Count; i++)
			{
				T2 element;
				if (i < monoBehaviours.Count)
				{
					element = monoBehaviours[i];
					if (!element.gameObject.activeSelf)
					{
						element.gameObject.SetActive(true);
					}
				}
				else
				{
					element = Instantiate(prefab, parent);
					onInstantiate?.Invoke(i, data[i], element);
					monoBehaviours.Add(element);
				}

				setUp(i, data[i], element);
			}

			// Disable any extra UI elements that we aren't using
			for (int i = data.Count; i < monoBehaviours.Count; i++)
			{
				T2 element = monoBehaviours[i];
				if (element.gameObject.activeSelf)
				{
					element.gameObject.SetActive(false);
				}
			}
		}
	}
}
