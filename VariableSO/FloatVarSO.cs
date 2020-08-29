using UnityEngine;

[System.Serializable]
public class FloatVarSO : VariableSO<float> { }

[System.Serializable]
public class FloatVarReference : VariableReference<FloatVarSO, float>
{
	[SerializeField] FloatState _value;
	protected override IValueState<float> State => _value;
	public FloatVarReference( float startValue = default( float ) ) { _value = new FloatState( startValue ); }
}
