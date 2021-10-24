﻿using System;
using UnityEngine;

static class PoolsManager
{
	private static PoolPart[] _pools = null;
	private static GameObject _root = null;

	[Serializable]
	public struct PoolPart
	{
		public int prefabId;
		public PooledObject prefab;
		public int count;
		public ObjectPool pool;
	}

	public static void Initialize(PoolPart[] newPools)
	{
		_pools = newPools;
		_root = new GameObject();
		_root.name = "Pool";
		for (int i = 0; i < _pools.Length; i++)
		{
			if (_pools[i].prefab != null)
			{
				_pools[i].pool = new ObjectPool(_pools[i].count, _pools[i].prefab, _root.transform);
			}
		}
	}


	public static PooledObject GetObject(int id, Vector3 position, Quaternion rotation)
	{
		PooledObject result = null;
		if (_pools != null)
		{
			for (int i = 0; i < _pools.Length; i++)
			{
				if (_pools[i].prefabId == id)
				{
					result = _pools[i].pool.GetObject();
					result.transform.position = position;
					result.transform.rotation = rotation;
					result.gameObject.SetActive(true);
					return result;
				}
			}
		}
		return result;
	}


}
