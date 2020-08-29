using UnityEngine;


public abstract class ValueVariableSO<T> : ScriptableObject, IValueState<T> where T : struct
{
	protected abstract IValueState<T> State { get; }

	public T Value => State.Value;
	public IEventRegister<T> OnChange => State.OnChange;
	public T Get() => State.Get();
	public void Setter( T t ) => State.Setter( t );

#if UNITY_EDITOR
	public void EditorChangeValue( T value )
	{
		State.Setter( value );
		UnityEditor.EditorUtility.SetDirty( this );
	}
#endif
}

[System.Serializable]
public abstract class ValueVariableReference<refT, T> : IValueState<T> where refT : ValueVariableSO<T> where T : struct
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