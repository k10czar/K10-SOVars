using UnityEngine;

[System.Serializable]
public class DoubleVarSO : ValueVariableSO<double>
{
	[SerializeField] DoubleState _value;
	protected override IValueState<double> State => _value;
}

[System.Serializable]
public class DoubleVarReference : ValueVariableReference<DoubleVarSO, double>
{
	[SerializeField] DoubleState _value;
	protected override IValueState<double> State => _value;
	public DoubleVarReference( double startValue = default( double ) ) { _value = new DoubleState( startValue ); }
}