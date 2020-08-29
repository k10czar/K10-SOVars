using UnityEngine;

public abstract class ConstantSO<T> : ScriptableObject
{
	[SerializeField] T _value;
	public T Value => _value;

#if UNITY_EDITOR
	public void EditorChangeValue( T value )
	{
		_value = value;
		UnityEditor.EditorUtility.SetDirty( this );
	}
#endif
}

[System.Serializable]
public abstract class ConstantReference<refT, T> where refT : ConstantSO<T>
{
	[SerializeField] T _value;
	[SerializeField] refT _reference;

	public T Value => _reference != null ? _reference.Value : _value;

	public ConstantReference( T startValue = default( T ) )
	{
		_value = startValue;
	}
}