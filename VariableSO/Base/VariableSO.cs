using UnityEngine;


public abstract class VariableSO<T> : ScriptableObject, IValueState<T> where T : struct
{
	[SerializeField] ValueState<T> _value = new ValueState<T>();

	public T Value => _value.Value;
	public IEventRegister<T> OnChange => _value.OnChange;
	public T Get() => _value.Get();
	public void Setter( T t ) => _value.Setter( t );

#if UNITY_EDITOR
	public void EditorChangeValue( T value )
	{
		_value.Value = value;
		UnityEditor.EditorUtility.SetDirty( this );
	}
#endif
}

[System.Serializable]
public abstract class VariableReference<refT, T> : IValueState<T> where refT : VariableSO<T> where T : struct
{
	[SerializeField] refT _reference;

	protected abstract IValueState<T> State { get; }

	public T Value => State.Value;
	public IEventRegister<T> OnChange => State.OnChange;
	public T Get() => State.Get();
	public void Setter( T t ) => State.Setter( t );

	void Start()
	{
		if( _reference == null ) return;
		State.Synchronize( _reference );
		_reference.Synchronize( State );
	}
}