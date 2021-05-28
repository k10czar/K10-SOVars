using UnityEngine;

public abstract class ReferenceVariableSO<T> : ScriptableObject, ICachedReference<T> //where T : class
{
	protected abstract ICachedReference<T> Reference { get; }

	public T CurrentReference => Reference.CurrentReference;
	public IEventRegister<T,IEventValidator> OnReferenceSet => Reference.OnReferenceSet;
	public IEventRegister<T> OnReferenceRemove => Reference.OnReferenceRemove;
	public IEventValidator Validator => Reference.Validator;
	public bool IsNull => Reference.IsNull;

	public void ChangeReference( T newRef ) { Reference.ChangeReference( newRef ); }
	public void Clear() { Reference.Clear(); }

#if UNITY_EDITOR
	public void EditorChangeValue( T value )
	{
		Reference.ChangeReference( value );
		UnityEditor.EditorUtility.SetDirty( this );
	}
#endif
}

[System.Serializable]
public abstract class ReferenceVariableReference<refT, T> : ICachedReference<T> where refT : ReferenceVariableSO<T> //where T : class
{
	[SerializeField] refT _reference;
	protected abstract ICachedReference<T> Reference { get; }

	public T CurrentReference => Reference.CurrentReference;
	public IEventRegister<T,IEventValidator> OnReferenceSet => Reference.OnReferenceSet;
	public IEventRegister<T> OnReferenceRemove => Reference.OnReferenceRemove;
	public IEventValidator Validator => Reference.Validator;
	public bool IsNull => Reference.IsNull;

	public void ChangeReference( T newRef ) { Reference.ChangeReference( newRef ); }
	public void Clear() { Reference.Clear(); }

	void Start()
	{
		if( _reference == null ) return;
		Reference.Synchronize( _reference.ChangeReference );
		_reference.Synchronize( Reference.ChangeReference );
	}
}
