using UnityEngine;

[System.Serializable]
public class FloatVarSO : ValueVariableSO<float>
{
	[SerializeField] FloatState _value;
	protected override IValueState<float> State => _value;
}

[System.Serializable]
public class FloatVarReference : ValueVariableReference<FloatVarSO, float>
{
	[SerializeField] FloatState _value;
	protected override IValueState<float> State => _value;
	public FloatVarReference( float startValue = default( float ) ) { _value = new FloatState( startValue ); }
}